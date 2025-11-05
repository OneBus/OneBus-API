using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using System.Linq.Expressions;

namespace OneBus.Infra.Data.Repositories
{
    public class LineTimeRepository : BaseRepository<LineTime, LineTimeFilter>, ILineTimeRepository
    {
        public LineTimeRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<LineTime, bool>> ApplyFilter(LineTimeFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.DayType == null || c.DayType == filter.DayType) &&
                (filter.DirectionType == null || c.Line!.DirectionType == filter.DirectionType) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.Line!.Name.ToLower().Contains(value) ||
                c.Line.Mileage.ToString().Contains(value) ||
                c.Line.Number.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
