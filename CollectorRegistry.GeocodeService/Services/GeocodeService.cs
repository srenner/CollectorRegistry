using CollectorRegistry.GeocodeService;
using Grpc.Core;

namespace CollectorRegistry.GeocodeService.Services
{
    public class GeocodeService : Geocoder.GeocoderBase
    {
        private readonly ILogger<GeocodeService> _logger;
        public GeocodeService(ILogger<GeocodeService> logger)
        {
            _logger = logger;
        }

        public override Task<GeocodeReply> GetCoordinates(GeocodeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GeocodeReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
