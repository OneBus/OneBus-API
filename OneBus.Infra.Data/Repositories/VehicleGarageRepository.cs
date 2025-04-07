using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class VehicleGarageRepository : BaseRepository<VehicleGarage, BaseFilter>, IVehicleGarageRepository
    {
        public VehicleGarageRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
