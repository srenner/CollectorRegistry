using CollectorRegistry.GeocodeService.Settings;
using CollectorRegistry.Shared.MessageRecords;
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
        private readonly IOptions<GeocodeSettings> _settings;

        public ConsoleHostedService(ILogger<ConsoleHostedService> logger, IHostApplicationLifetime appLifetime, IOptions<GeocodeSettings> settings)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _settings = settings;
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
                        _logger.LogInformation("Using API @ " + _settings.Value.BaseURL);

                        var factory = new ConnectionFactory { HostName = "rabbit01", VirtualHost = "/", UserName = "guest", Password = "guest", ClientProvidedName = "GeocodeService" };
                        using var connection = factory.CreateConnection();
                        using var channel = connection.CreateModel();

                        channel.QueueDeclare(queue: "geocode-input",
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            var inputRecord = JsonSerializer.Deserialize<GeocodeInput>(message);
                        };

                        while (true)
                        {
                            channel.BasicConsume(queue: "geocode-input",
                                                 autoAck: true,
                                                 consumer: consumer);
                            await Task.Delay(_settings.Value.RateLimitMillis);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception: " + ex.Message);
                    }
                    finally
                    {
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
