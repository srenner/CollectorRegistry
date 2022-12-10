using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using CollectorRegistry.Server.Repos;

namespace CollectorRegistry.Server.RegistryAggregate
{
    public interface ISiteRepository// : IRepository<Site>
    {
        Site Add(Site site);
        void Update(Site site);
        Task<Site> GetAsync(int siteID);
    }
}
