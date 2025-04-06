using OneBus.Domain.Entities;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseReadOnlyRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<bool> EnableAsync(TEntity entity, CancellationToken cancellationToken = default); 

        Task<bool> DisableAsync(TEntity entity, CancellationToken cancellationToken = default);        
    }
}
