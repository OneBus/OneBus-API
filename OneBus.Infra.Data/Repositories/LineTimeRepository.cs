using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class LineTimeRepository : BaseRepository<LineTime, BaseFilter>, ILineTimeRepository
    {
        public LineTimeRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
