using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle, BaseFilter>, IVehicleRepository
    {
        public VehicleRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
