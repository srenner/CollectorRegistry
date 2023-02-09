using CollectorRegistry.Server.Repos;
using CollectorRegistry.Server.Services;
using CollectorRegistry.Shared.Protos;
using Grpc.Core;

namespace CollectorRegistry.Server.gRPC
{
    public class GeocodeService : CollectorRegistry.Shared.Protos.Geocode.GeocodeBase
    {
        private readonly ILogger<GeocodeService> _logger;
        private readonly IEntryRepository _entryRepository;

        public GeocodeService(ILogger<GeocodeService> logger, IEntryRepository entryRepository)
        {
            _logger = logger;
            _entryRepository = entryRepository;
        }

        public override async Task<GeocodeResponse> UpdateEntry(GeocodeUpdateRequest request, ServerCallContext context)
        {
            bool isSuccess = false;
            string message = DateTime.Now.ToString();

            var svc = new EntryDataService(_entryRepository, -1);
            await svc.UpdateEntryGeocode(new Shared.MessageRecords.GeocodeOutput
            {
                EntryID = request.EntryId,
                GeoDescription = request.GeoDescr,
                GeoLat = request.GeoLat,
                GeoLong = request.GeoLong
            });


            return Task.FromResult(new GeocodeResponse
            {
                IsSuccess = isSuccess,
                Message = message
            }).Result;
        }
    }
}
