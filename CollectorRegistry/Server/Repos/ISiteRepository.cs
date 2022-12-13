using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using CollectorRegistry.Server.Repos;

namespace CollectorRegistry.Server.RegistryAggregate
{
    public interface ISiteRepository// : IRepository<Site>
    {
        Task<IEnumerable<Site>> GetSites();
        Task<Site> GetSite(int siteID);
    }
}
