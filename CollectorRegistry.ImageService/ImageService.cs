using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        //private readonly IOptions<ConnectionSettings> _settings;

        private IModel _channel;
        private IConnection _connection;
        private EventingBasicConsumer _consumer;

        public ImageService(ILogger<ImageService> logger, IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
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

                        while (!cancellationToken.IsCancellationRequested)
                        {
                            Task.Delay(-1);
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
