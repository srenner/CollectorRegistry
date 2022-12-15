using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using CollectorRegistry.Server.ModelExtensions;
using CollectorRegistry.Server.Repos;
using CollectorRegistry.Shared.ResultModels;

namespace CollectorRegistry.Server.Services
{
    public class ItemDataService
    {

        private readonly IItemRepository _repo;
        private int _siteID = 0;

        public ItemDataService(IItemRepository repo, int siteID)
        {
            _repo = repo;
            _siteID = siteID;
        }

        public async Task<ItemFindResultModel> FindItemBySerialNumber(string searchText)
        {
            var result = new ItemFindResultModel();
            var item = await _repo.FindItemBySerialNumber(_siteID, searchText);
            if (item == null)
            {
                result.IsFound = false;
                result.IsPatternMatch = true; //todo
            }
            else
            {
                result.IsFound = true;
                result.IsPatternMatch = true;
                result.Item = item.ToViewModel();
            }
            return result;
        }

    }
}
