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
                .Include(i => i.Site)
                .Where(w => w.SerialNumber == serialNumberSearch)
                .Where(w => w.SiteID == siteID)
                .FirstOrDefaultAsync();
        }

        public async Task<Item> Add(int siteID, string serialNumber)
        {
            Item item = new Item { SiteID = siteID, SerialNumber = serialNumber };

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
