using CollectorRegistry.Server.AggregatesModel.ItemAggregate;

namespace CollectorRegistry.Server.Repos
{
    public interface IItemRepository
    {
        public Task<Item> GetItemByID(int itemID);
        public Task<Item> FindItemBySerialNumber(int siteID, string serialNumberSearch);
        public Task<Item> Add(int siteID, string serialNumber);
    }
}
