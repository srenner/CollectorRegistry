using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace CollectorRegistry.TestConsole
{
    public class RabbitWorker : BackgroundService
    {
        private readonly IBus _bus;

        public RabbitWorker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //GetSendEndpoint(new Uri("queue:input-queue"))

                //await _bus

                RabbitWorker rw = new RabbitWorker();



                await _bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}