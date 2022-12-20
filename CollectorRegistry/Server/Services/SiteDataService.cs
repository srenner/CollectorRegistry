using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using CollectorRegistry.Server.RegistryAggregate;

namespace CollectorRegistry.Server.Services
{
    public class SiteDataService
    {
        private readonly ISiteRepository _repo;
        public SiteDataService(ISiteRepository repo) 
        {
            _repo = repo;
        }

        public async Task<Site> GetSite(int siteID)
        {
            return await _repo.GetSite(siteID);
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            return await _repo.GetSites();
        }
    }
}
