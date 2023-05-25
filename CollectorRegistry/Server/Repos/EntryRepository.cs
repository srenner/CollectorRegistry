using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace CollectorRegistry.Server.Repos
{
    public class EntryRepository : IEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public EntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entry> GetRandomEntry(int? siteID, int statusID)
        {
            // TODO - ditch the if/else
            if(siteID.HasValue)
            {
                return await _context.Entries
                    .Include(i => i.Item)
                    .Where(w => w.Item.SiteID == siteID)
                    .Where(w => w.EntryStatusID == Enum.EntryStatusEnum.Complete.ID)
                    .OrderBy(o => Guid.NewGuid()) //randomness
                    .Take(1).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Entries
                    .Include(i => i.Item)
                    .Where(w => w.EntryStatusID == Enum.EntryStatusEnum.Complete.ID)
                    .OrderBy(o => Guid.NewGuid()) //randomness
                    .Take(1).FirstOrDefaultAsync();
            }
        }

        public async Task<Entry> GetEntry(int entryID)
        {
            return await _context.Entries
                .Include(i => i.EntryValues)
                .Include(i => i.Item.Site)
                .Where(w => w.EntryID == entryID)
                .FirstOrDefaultAsync();
        }

        public async Task<Entry> UpdateEntry(Entry entry)
        {
            _context.Update(entry);
            await _context.SaveChangesAsync();
            return entry;
        }
    }
}
