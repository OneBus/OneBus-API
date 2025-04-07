using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TFilter> : BaseReadOnlyRepository<TEntity, TFilter>, IBaseRepository<TEntity, TFilter>
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        protected BaseRepository(OneBusDbContext dbContext) : base(dbContext) { }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }      

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
