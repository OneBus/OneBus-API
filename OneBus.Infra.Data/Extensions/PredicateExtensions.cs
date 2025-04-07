using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Extensions
{
    public static class PredicateExtensions
    {
        public static Predicate<TEntity> AndApply<TEntity>(this Predicate<TEntity> predicate, Predicate<TEntity> newPredicate)
            where TEntity : BaseEntity
        {
            return c => predicate(c) && newPredicate(c);
        }
    }
}
