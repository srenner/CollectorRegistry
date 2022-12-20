using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using Microsoft.EntityFrameworkCore;

namespace CollectorRegistry.Server.RegistryAggregate
{
    public class SiteRepository : ISiteRepository
    {
        private readonly ApplicationDbContext _context;

        public SiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            try
            {
                return await _context.Sites
                    .Where(w => w.IsActive)
                    .Where(w => w.IsApproved)
                    .Where(w => w.IsDeleted == false)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Site> GetSite(int siteID)
        {
            return await _context.Sites.Where(w => w.SiteID == siteID).FirstOrDefaultAsync();
        }
    }
}
