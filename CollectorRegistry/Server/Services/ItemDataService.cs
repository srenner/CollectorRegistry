using CollectorRegistry.Server.AggregatesModel.ItemAggregate;
using CollectorRegistry.Server.ModelExtensions;
using CollectorRegistry.Server.RegistryAggregate;
using CollectorRegistry.Server.Repos;
using CollectorRegistry.Shared.ResultModels;
using System.Runtime.CompilerServices;

namespace CollectorRegistry.Server.Services
{
    public class ItemDataService
    {
        private readonly IItemRepository _itemRepo;
        private int _siteID = 0;

        public ItemDataService(IItemRepository itemRepo, int siteID)
        {
            _itemRepo = itemRepo;
            _siteID = siteID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>an Item if found, null if not found</returns>
        public async Task<Item?> FindItemBySerialNumber(string searchText)
        {
            var item = await _itemRepo.FindItemBySerialNumber(_siteID, searchText);
            return item;
        }

    }
}
