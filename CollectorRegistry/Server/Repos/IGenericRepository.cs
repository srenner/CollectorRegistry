namespace CollectorRegistry.Server.Repos
{
    public interface IGenericRepository
    {
        Task<T> AddEntity<T>(T entity) where T : class;
        Task<T> AddOrUpdateEntity<T>(T entity) where T : class;
        Task DeleteEntity<T>(T entity) where T : class;
        Task<T> GetEntity<T>(int id) where T : class;

        Task<IEnumerable<T>> GetAllEntities<T>() where T : class;
    }
}
