using CollectorRegistry.Shared;
using CollectorRegistry.Shared.Geocode;
using CollectorRegistry.Shared.Protos;
using Grpc.Net.Client;
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

namespace CollectorRegistry.DataBridge
{
    internal class DataBridgeService : IHostedService
    {
        private readonly ILogger<DataBridgeService> _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IOptions<ConnectionSettings> _settings;

        public DataBridgeService(ILogger<DataBridgeService> logger, IHostApplicationLifetime appLifetime, IOptions<ConnectionSettings> settings)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _settings = settings;


        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStopping.Register(() =>
            {
                _logger.LogDebug("Closing RabbitMQ connection");
            });

            _appLifetime.ApplicationStopped.Register(OnStopped);
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run( async () =>
                {
                    try
                    {

                        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

                        bool canConnect = false;
                        while (!canConnect)
                        {
                            _logger.LogDebug("Pinging " + _settings.Value.RabbitMQHostName);
                            var pingReply = Utility.Ping(_settings.Value.RabbitMQHostName);
                            if (pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                            {
                                canConnect = true;
                                _logger.LogDebug("Ping success. Establishing connection with RabbitMQ.");
                                //todo investigate why we can't connect right away and why recovery fails in this scenario
                                //possible issue with docker
                                await Task.Delay(10000);
                            }
                            else
                            {
                                _logger.LogDebug("Ping failed: " + _settings.Value.RabbitMQHostName);
                                await Task.Delay(5000);
                            }
                        }


                        var factory = new ConnectionFactory
                        {
                            HostName = _settings.Value.RabbitMQHostName,
                            VirtualHost = _settings.Value.RabbitMQVirtualHost,
                            UserName = _settings.Value.RabbitMQUsername,
                            Password = _settings.Value.RabbitMQPassword,
                            ClientProvidedName = "DataBridge"
                        };


                        using (var connection = factory.CreateConnection())
                        {
                            _logger.LogDebug("Connected to " + _settings.Value.RabbitMQHostName);
                            using (var channel = connection.CreateModel())
                            {
                                var consumer = new EventingBasicConsumer(channel);
                                consumer.Received += (sender, e) => {
                                    string queue = e.RoutingKey;
                                    bool isProcessed = false;
                                    _logger.LogDebug("Received from queue: " + queue);
                                    if (queue == _settings.Value.RabbitMQGeocodeQueue)
                                    {
                                        var message = Encoding.UTF8.GetString(e.Body.Span);
                                        var outputRecord = JsonSerializer.Deserialize<GeocodeOutput>(message);

                                        var request = new GeocodeUpdateRequest
                                        {
                                            EntryId = outputRecord.EntryID,
                                            GeoDescr = outputRecord.GeoDescription,
                                            GeoLat = outputRecord.GeoLat.GetValueOrDefault(),
                                            GeoLong = outputRecord.GeoLong.GetValueOrDefault()
                                        };

                                        UnaryGeocodeUpdate(request);
                                        isProcessed = true;
                                    }
                                    else
                                    {
                                        _logger.LogDebug("Unknown queue: " + queue);
                                    }
                                    if (isProcessed)
                                    {
                                        channel.BasicAck(e.DeliveryTag, false);
                                    }

                                };
                                string[] queues = { _settings.Value.RabbitMQGeocodeQueue };
                                if (channel.IsOpen)
                                {
                                    foreach (string queue in queues)
                                    {
                                        channel.QueueDeclare(queue: queue,
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);
                                        channel.BasicConsume(queue, false, consumer);
                                    }
                                }
                                else
                                {
                                    _logger.LogDebug("Cannot declare queues on closed channel");
                                }
                            }
                        }

                        while (!cancellationToken.IsCancellationRequested)
                        {
                            await Task.Delay(-1);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception: " + ex.Message);
                    }
                    finally
                    {
                        _logger.LogDebug("Stopping DataBridge");
                        _appLifetime.StopApplication();
                    }
                });
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;


        private void OnStopped()
        {
            // ...
        }



        private void UnaryGeocodeUpdate(GeocodeUpdateRequest request)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress(_settings.Value.gRPCAddress, new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Geocode.GeocodeClient(channel);
            var reply = client.UpdateEntry(request);
            _logger.LogDebug("Message from geocode gRPC call: " + reply.Message.ToString());
        }

    }
}
