using CollectorRegistry.ImageService.Settings;
using CollectorRegistry.Shared;
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

namespace CollectorRegistry.ImageService
{
    internal class ImageService : IHostedService
    {
        private readonly ILogger<ImageService> _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IOptions<RabbitMQSettings> _rabbitSettings;
        private readonly IOptions<ImagesSettings> _imagesSettings;

        private IModel _channel;
        private IConnection _connection;
        private EventingBasicConsumer _consumer;

        public ImageService(ILogger<ImageService> logger, IHostApplicationLifetime appLifetime, IOptions<RabbitMQSettings> rabbitSettings, IOptions<ImagesSettings> imagesSettings)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _rabbitSettings = rabbitSettings;
            _imagesSettings = imagesSettings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

                        bool canConnect = false;
                        while (!canConnect)
                        {
                            _logger.LogDebug("Pinging " + _rabbitSettings.Value.HostName);
                            var pingReply = Utility.Ping(_rabbitSettings.Value.HostName);
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
                            ClientProvidedName = "ImageService",
                            AutomaticRecoveryEnabled = true
                        };
                        using (var connection = factory.CreateConnection())
                        {
                            _logger.LogDebug("Connected to " + _rabbitSettings.Value.HostName);
                            using (var channel = connection.CreateModel())
                            {
                                channel.QueueDeclare(queue: "image-input",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                                while (true)
                                {

                                    var consumer = new EventingBasicConsumer(channel);
                                    consumer.Received += (ch, ea) =>
                                    {
                                        ReadOnlyMemory<byte> body = ea.Body;
                                        var message = Encoding.UTF8.GetString(body.Span);
                                        _logger.LogDebug(message);
                                        channel.BasicAck(ea.DeliveryTag, false);
                                    };
                                    // this consumer tag identifies the subscription
                                    // when it has to be cancelled
                                    string consumerTag = channel.BasicConsume("image-input", false, consumer);


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
                        _logger.LogDebug("Stopping ImageService");
                        _appLifetime.StopApplication();
                    }
                });
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private void OnStopping()
        {
            _connection.Close();
        }

        private void OnStopped()
        {
            // ...
        }
    }
}
