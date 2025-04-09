using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TEntity, TFilter> 
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        Task<TEntity?> GetOneAsync(
            Predicate<TEntity> predicate, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetManyAsync(
            Predicate<TEntity> predicate, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetPaginedAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default);

        Task<ulong> LongCountAsync(
            TFilter filter, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default);
    }
}
