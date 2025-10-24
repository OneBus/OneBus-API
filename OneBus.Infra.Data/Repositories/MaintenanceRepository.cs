using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using System.Linq.Expressions;

namespace OneBus.Infra.Data.Repositories
{
    public class MaintenanceRepository : BaseRepository<Maintenance, MaintenanceFilter>, IMaintenanceRepository
    {
        public MaintenanceRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<Maintenance, bool>> ApplyFilter(MaintenanceFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.Sector == null || c.Sector == filter.Sector) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.Description.ToLower().Contains(value) ||
                c.Cost.ToString().Contains(value) ||
                c.Vehicle!.Model.ToLower().Contains(value) ||
                c.Vehicle.Plate.ToLower().Contains(value) ||
                c.Vehicle.Renavam.ToLower().Contains(value) ||
                c.Vehicle.Prefix.ToLower().Contains(value) ||
                c.Vehicle.Licensing!.ToLower().Contains(value) ||
                c.Vehicle.NumberChassis!.ToLower().Contains(value) ||
                c.Vehicle.BodyworkNumber!.ToLower().Contains(value) ||
                c.Vehicle.BusChassisModel!.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
