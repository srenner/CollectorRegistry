using Microsoft.EntityFrameworkCore;

namespace CollectorRegistry.Server.Repos
{
    public class GenericRepository : IGenericRepository
    {

        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Task<T> AddEntity<T>(T entity) where T : class 
        {
            throw new NotImplementedException();
        }

        public Task<T> AddOrUpdateEntity<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetEntity<T>(int id) where T : class
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);

            }
            catch(Exception ex)
            {
                throw;
            }
         }

        public async Task<IEnumerable<T>> GetAllEntities<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
