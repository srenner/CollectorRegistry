using CollectorRegistry.Server.AggregatesModel.ItemAggregate;
using Microsoft.EntityFrameworkCore;

namespace CollectorRegistry.Server.Repos
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Item> FindItemBySerialNumber(int siteID, string serialNumberSearch)
        {
            return await _context.Items
                .Where(w => w.SerialNumber == serialNumberSearch)
                .Where(w => w.SiteID == siteID)
                .FirstOrDefaultAsync();
        }

    }
}
