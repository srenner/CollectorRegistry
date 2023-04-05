using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Server.RegistryAggregate;
using CollectorRegistry.Server.Repos;
using CollectorRegistry.Shared.MessageQueue;

namespace CollectorRegistry.Server.Services
{
    public class EntryDataService
    {
        private readonly IEntryRepository _repo;
        private int _siteID = 0;

        public EntryDataService(IEntryRepository repo, int siteID)
        {
            _repo = repo;
            _siteID = siteID;
        }

        public async Task<Entry> GetRandomEntry(int? statusID = null)
        {
            statusID = statusID == null ? Enum.EntryStatusEnum.Complete.ID : statusID;
            return await _repo.GetRandomEntry(_siteID, statusID.Value);
        }

        public async Task UpdateEntryGeocode(GeocodeOutput go)
        {
            var entry = await _repo.GetEntry(go.EntryID);
            if(entry != null)
            {
                entry.GeoLat = go.GeoLat;
                entry.GeoLong = go.GeoLong;
                entry.GeoDescription = go.GeoDescription;
                entry.IsGeocoded = true;

                await _repo.UpdateEntry(entry);
            }
        }
    }
}
