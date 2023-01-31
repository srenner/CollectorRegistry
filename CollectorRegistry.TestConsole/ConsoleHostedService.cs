using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.TestConsole
{
    internal sealed class ConsoleHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IOptions<RabbitMQSettings> _settings;

        public ConsoleHostedService(ILogger<ConsoleHostedService> logger, IHostApplicationLifetime appLifetime, IOptions<RabbitMQSettings> settings)
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
                        var factory = new ConnectionFactory { HostName = _settings.Value.HostName, VirtualHost = _settings.Value.VirtualHost, UserName = _settings.Value.Username, Password = _settings.Value.Password };
                        using var connection = factory.CreateConnection();
                        using var channel = connection.CreateModel();

                        channel.QueueDeclare(queue: _settings.Value.HeartbeatQueue,
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);


                        while (true)
                        {
                            var message = DateTime.Now.ToString("F");
                            var body = Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish(exchange: string.Empty,
                                                 routingKey: _settings.Value.HeartbeatQueue,
                                                 basicProperties: null,
                                                 body: body);
                            await Task.Delay(1000);
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
