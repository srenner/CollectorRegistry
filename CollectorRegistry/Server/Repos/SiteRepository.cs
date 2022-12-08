using CollectorRegistry.Server.Models;
using CollectorRegistry.Server.Repos;

namespace CollectorRegistry.Server.RegistryAggregate
{
    public class SiteRepository : ISiteRepository
    {
        private readonly ApplicationDbContext _context;
        //public IUnitOfWork UnitOfWork => _context;

        public SiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Site Add(Site site)
        {
            throw new NotImplementedException();
        }
        public void Update(Site site)
        {
            throw new NotImplementedException();
        }

        public async Task<Site> GetAsync(int siteID)
        {
            throw new NotImplementedException();
        }
    }
}
