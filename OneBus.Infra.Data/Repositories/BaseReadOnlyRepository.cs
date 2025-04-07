using Microsoft.EntityFrameworkCore;
using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using OneBus.Infra.Data.Extensions;
using System.Linq.Dynamic.Core;

namespace OneBus.Infra.Data.Repositories
{
    public abstract class BaseReadOnlyRepository<TEntity, TFilter> : IBaseReadOnlyRepository<TEntity, TFilter>
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        protected readonly OneBusDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseReadOnlyRepository(OneBusDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(
            Predicate<TEntity> predicate,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Includes(dbQueryOptions)
                .Where(c => predicate(c))
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity?> GetOneAsync(
            Predicate<TEntity> predicate,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(c => predicate(c))
                .Includes(dbQueryOptions)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetPaginedAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            Predicate<TEntity> predicate = ApplyFilter(filter);

            //Using Skip|Take pagination
            return await _dbSet
                .Includes(dbQueryOptions)
                .Where(c => predicate(c))
                .OrderBy("{0} {1}", filter.OrderField, filter.OrderType)
                .Skip((int)((filter.CurrentPage - 1) * filter.PageSize))
                .Take((int)filter.PageSize)
                .ToListAsync(cancellationToken);
        }

        protected virtual Predicate<TEntity> ApplyFilter(TFilter filter)
        {
            return c
                => (filter.IsEnabled == null || (filter.IsEnabled.Value ? c.DeletedAt == null : c.DeletedAt != null)) &&
                   (filter.StartDateTime == null || filter.EndDateTime == null || (c.CreatedAt >= filter.StartDateTime && c.CreatedAt <= filter.EndDateTime));
        }
    }
}
