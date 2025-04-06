using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetOneAsync(Predicate<TEntity> predicate, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetManyAsync(Predicate<TEntity> predicate, CancellationToken cancellationToken = default);

        Task<Pagination<TEntity>> GetPaginedAsync<TFilter>(TFilter filter, CancellationToken cancellationToken = default)
            where TFilter : BaseFilter;
    }
}
