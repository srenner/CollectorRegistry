using CollectorRegistry.Server.AggregatesModel.EntryAggregate;

namespace CollectorRegistry.Server.Repos
{
    public interface IEntryRepository
    {
        public Task<Entry> GetRandomEntry(int siteID, int statusID);
        public Task<Entry> GetEntry(int entryID);
        public Task<Entry> UpdateEntry(Entry entry);

    }
}