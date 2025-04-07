using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class LineRepository : BaseRepository<Line, BaseFilter>, ILineRepository
    {
        public LineRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
