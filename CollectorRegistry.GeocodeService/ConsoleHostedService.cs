using CollectorRegistry.GeocodeService.Settings;
using CollectorRegistry.Shared;
using CollectorRegistry.Shared.MessageRecords;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollectorRegistry.GeocodeService
{

    internal sealed class ConsoleHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IOptions<GeocodeSettings> _geocodeSettings;
        private readonly IOptions<RabbitMQSettings> _rabbitSettings;

        public ConsoleHostedService(ILogger<ConsoleHostedService> logger, IHostApplicationLifetime appLifetime, IOptions<GeocodeSettings> geocodeSettings, IOptions<RabbitMQSettings> rabbitSettings)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _geocodeSettings = geocodeSettings;
            _rabbitSettings = rabbitSettings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        bool canConnect = false;
                        while (!canConnect)
                        {
                            _logger.LogDebug("Pinging " + _rabbitSettings.Value.HostName);
                            var pingReply = Utility.Ping(_rabbitSettings.Value.HostName);
                            if(pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                            {
                                canConnect = true;
                                _logger.LogDebug("Ping success. Establishing connection with RabbitMQ.");
                                //todo investigate why we can't connect right away and why recovery fails in this scenario
                                //possible issue with docker
                                await Task.Delay(10000);
                            }
                            else
                            {
                                _logger.LogDebug("Ping failed: " + _rabbitSettings.Value.HostName);
                                await Task.Delay(5000);
                            }
                        }

                        var factory = new ConnectionFactory
                        {
                            HostName = _rabbitSettings.Value.HostName,
                            VirtualHost = _rabbitSettings.Value.VirtualHost,
                            UserName = _rabbitSettings.Value.Username,
                            Password = _rabbitSettings.Value.Password,
                            ClientProvidedName = "GeocodeService",
                            AutomaticRecoveryEnabled = true
                        };
                        using (var connection = factory.CreateConnection())
                        {
                            _logger.LogDebug("Connected to " + _rabbitSettings.Value.HostName);
                            _logger.LogInformation("Using API @ " + _geocodeSettings.Value.BaseURL);
                            using (var channel = connection.CreateModel())
                            {
                                channel.QueueDeclare(queue: "geocode-input",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                                var geoService = new GeocodeService(_geocodeSettings.Value);

                                //using the pull API to more easily implement rate limiting the external geocode API
                                //https://www.rabbitmq.com/dotnet-api-guide.html#basic-get
                                while (true)
                                {
                                    BasicGetResult result = channel.BasicGet("geocode-input", false);
                                    if (result == null)
                                    {
                                        // No message available at this time.
                                    }
                                    else
                                    {
                                        IBasicProperties props = result.BasicProperties;
                                        ReadOnlyMemory<byte> body = result.Body;
                                        var message = Encoding.UTF8.GetString(body.Span);
                                        var inputRecord = JsonSerializer.Deserialize<GeocodeInput>(message);

                                        var outputResultList = await geoService.Run(inputRecord.City, inputRecord.Region, inputRecord.PostalCode, inputRecord.Country);

                                        //result is sorted by descending relevance
                                        //for now we assume the first entry is correct
                                        //future updates could possibly present the user with a selection list
                                        if (outputResultList.Count > 0)
                                        {
                                            var outputResult = outputResultList[0];
                                            var outputRecord = new GeocodeOutput
                                            {
                                                EntryID = inputRecord.EntryID,
                                                GeoDescription = outputResult.DisplayName,
                                                GeoLat = outputResult.GeoLat,
                                                GeoLong = outputResult.GeoLong
                                            };
                                            message = JsonSerializer.Serialize(outputRecord);
                                            body = Encoding.UTF8.GetBytes(message);
                                            using (var outputChannel = connection.CreateModel())
                                            {
                                                outputChannel.QueueDeclare(queue: "geocode-output",
                                                    durable: true,
                                                    exclusive: false,
                                                    autoDelete: false,
                                                    arguments: null);

                                                outputChannel.BasicPublish(exchange: string.Empty,
                                                    routingKey: "geocode-output",
                                                    basicProperties: null,
                                                    body: body);
                                            }
                                        }
                                        channel.BasicAck(result.DeliveryTag, false);
                                    }
                                    await Task.Delay(_geocodeSettings.Value.RateLimitMillis);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception: " + ex.Message);
                    }
                    finally
                    {
                        _logger.LogDebug("Stopping...");
                        _appLifetime.StopApplication();
                    }
                });
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
