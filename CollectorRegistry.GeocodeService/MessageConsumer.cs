using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.GeocodeService
{

    public class MessageConsumer : IConsumer<MessageContract>
    {
        private readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        Task IConsumer<MessageContract>.Consume(ConsumeContext<MessageContract> context)
        {
            _logger.LogInformation("Received Text: {Text}", context.Message);
            return Task.CompletedTask;
        }
    }
}
