using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using System.Linq.Expressions;

namespace OneBus.Infra.Data.Repositories
{
    public class LineRepository : BaseRepository<Line, LineFilter>, ILineRepository
    {
        public LineRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<Line, bool>> ApplyFilter(LineFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.Type == null || c.Type == filter.Type) &&
                (filter.DirectionType == null || c.DirectionType == filter.DirectionType) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.Name.ToLower().Contains(value) ||
                c.Mileage.ToString().Contains(value) ||
                c.Number.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
