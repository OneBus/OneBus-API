using Microsoft.EntityFrameworkCore;
using OneBus.Domain.Commons;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> Includes<TEntity>(
            this IQueryable<TEntity> query, 
            DbQueryOptions? dbQueryOptions = null) where TEntity : BaseEntity
        {
            if (dbQueryOptions is { Includes.Length: 0 })
                return query;

            foreach (string include in dbQueryOptions!.Includes!)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
