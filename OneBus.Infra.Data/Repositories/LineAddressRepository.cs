using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class LineAddressRepository : BaseRepository<LineAddress, BaseFilter>, ILineAddressRepository
    {
        public LineAddressRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
