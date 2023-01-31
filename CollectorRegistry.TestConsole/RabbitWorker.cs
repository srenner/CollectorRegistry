using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollectorRegistry.TestConsole
{
    public class RabbitWorker : BackgroundService
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public RabbitWorker(IBus bus, ILogger<RabbitWorker> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("ExecuteAsync()");
            await _bus.GetSendEndpoint(new Uri("queue:test"));

            while (!stoppingToken.IsCancellationRequested)
            {

                string strNow = $"The time is {DateTimeOffset.Now}";

                _logger.LogInformation(strNow);
                //var endpoint = await busControl.GetSendEndpoint(new Uri("queue:order-service"));
                await _bus.Publish(new Message { Text = strNow }, stoppingToken);
                
                //await _bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
