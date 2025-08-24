using Microsoft.EntityFrameworkCore;
using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using OneBus.Infra.Data.Extensions;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query
                .Where(expression)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<TEntity, bool>> expression = ApplyFilter(filter);

            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query
                .Where(expression)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query
                .Where(expression)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetPaginedAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<TEntity, bool>> expression = ApplyFilter(filter);

            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query
                .Where(expression)
                .OrderBy($"{filter.OrderField} {filter.OrderType}")
                .Skip((int)((filter.CurrentPage - 1) * filter.PageSize))
                .Take((int)filter.PageSize)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<long> LongCountAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query
                .Where(expression)
                .LongCountAsync(cancellationToken);
        }

        public virtual async Task<long> LongCountAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<TEntity, bool>> expression = ApplyFilter(filter);

            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query
                .Where(expression)
                .LongCountAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>> expression,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = ApplyDbQueryOptions(dbQueryOptions);

            return await query.AnyAsync(expression, cancellationToken);
        }

        protected virtual IQueryable<TEntity> ApplyDbQueryOptions(DbQueryOptions? dbQueryOptions)
        {
            IQueryable<TEntity> query = _dbSet;

            if (dbQueryOptions is null)
                return query;

            query = query.Includes(dbQueryOptions.Includes);

            if (dbQueryOptions is { IgnoreQueryFilter: false })
                return query;

            return query.IgnoreQueryFilters();
        }

        protected virtual Expression<Func<TEntity, bool>> ApplyFilter(TFilter filter)
        {
            return _ => true;
        }
    }
}
