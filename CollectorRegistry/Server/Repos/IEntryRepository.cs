using CollectorRegistry.Server.AggregatesModel.EntryAggregate;

namespace CollectorRegistry.Server.Repos
{
    public interface IEntryRepository
    {
        public Task<Entry> GetRandomEntry(int siteID, int statusID);
    }
}