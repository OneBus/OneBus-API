using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TFilter> : IBaseReadOnlyRepository<TEntity, TFilter>
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
