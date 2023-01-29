using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerTestWorker
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public Worker(ILogger logger, IBus bus)
        {
            _bus = bus;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTimeOffset.Now;
                await _bus.Publish(now, stoppingToken);
                _logger.LogDebug("published " + now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
