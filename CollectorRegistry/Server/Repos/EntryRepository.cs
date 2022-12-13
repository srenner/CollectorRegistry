using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using Microsoft.EntityFrameworkCore;

namespace CollectorRegistry.Server.Repos
{
    public class EntryRepository : IEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public EntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entry> GetRandomEntry(int siteID, int statusID)
        {
            if(true)
            {
                return await _context.Entries
                    .Where(w => w.Item.SiteID == siteID)
                    .Where(w => w.EntryStatusID == Enum.EntryStatusEnum.Complete.ID)
                    .Take(1).FirstOrDefaultAsync();
            }
        }
    }
}
