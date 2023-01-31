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

        public ConsoleHostedService(ILogger<ConsoleHostedService> logger, IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
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
                        var factory = new ConnectionFactory { HostName = "rabbit01", VirtualHost = "/", UserName = "guest", Password = "guest" };
                        using var connection = factory.CreateConnection();
                        using var channel = connection.CreateModel();

                        channel.QueueDeclare(queue: "test-heartbeat",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);


                        while (true)
                        {
                            var message = DateTime.Now.ToString("F");
                            var body = Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish(exchange: string.Empty,
                                                 routingKey: "test-heartbeat",
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
