using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using System.Linq.Expressions;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TEntity, TFilter> 
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetManyAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetManyAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetPaginedAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);

        Task<long> LongCountAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);

        Task<long> LongCountAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default);
    }
}
