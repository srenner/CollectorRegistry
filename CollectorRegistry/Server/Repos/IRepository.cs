using CollectorRegistry.Server.Aggregates;

namespace CollectorRegistry.Server.Repos
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
