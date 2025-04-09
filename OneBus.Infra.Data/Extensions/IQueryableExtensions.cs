using Microsoft.EntityFrameworkCore;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Extensions
{
    public static class IQueryableExtensions
    {        
        public static IQueryable<TEntity> Includes<TEntity>(
            this IQueryable<TEntity> query, 
            string[]? includes) where TEntity : BaseEntity
        {
            if (includes == null || includes.Length == 0)
                return query;

            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
