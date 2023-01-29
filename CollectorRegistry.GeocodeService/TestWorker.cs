using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.GeocodeService
{
    internal class TestWorker : BackgroundService
    {
        readonly IBus _bus;

        public TestWorker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new MessageContract { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
