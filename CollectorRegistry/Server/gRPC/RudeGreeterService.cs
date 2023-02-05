using CollectorRegistry.Shared.Protos;
using Grpc.Core;

namespace CollectorRegistry.Server.gRPC
{
    public class RudeGreeterService : RudeGreeter.RudeGreeterBase
    {
        private readonly ILogger<RudeGreeterService> _logger;
        public RudeGreeterService(ILogger<RudeGreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<RudeReply> BeRude(RudeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RudeReply
            {
                Message = "Get bent, " + request.Name
            });
        }
    }
}
