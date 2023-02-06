using CollectorRegistry.Shared.Protos;
using Grpc.Core;

namespace CollectorRegistry.Server.gRPC
{
    public class GeocodeService : CollectorRegistry.Shared.Protos.Geocode.GeocodeBase
    {
        private readonly ILogger<GeocodeService> _logger;

        public GeocodeService(ILogger<GeocodeService> logger)
        {
            _logger = logger;
        }

        public override Task<GeocodeResponse> UpdateEntry(GeocodeUpdateRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GeocodeResponse
            {
                Message = "Hello " + request.GeoDescr
            });
        }
    }
}
