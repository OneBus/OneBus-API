using OneBus.Domain.Filters;
using OneBus.Domain.Entities;
using System.Linq.Expressions;
using OneBus.Infra.Data.DbContexts;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Infra.Data.Repositories
{
    public class VehicleOperationRepository : BaseRepository<VehicleOperation, VehicleOperationFilter>, IVehicleOperationRepository
    {
        public VehicleOperationRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<VehicleOperation, bool>> ApplyFilter(VehicleOperationFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.LineType == null || c.LineTime!.Line!.Type == filter.LineType) &&
                (filter.VehicleType == null || c.Vehicle!.Type == filter.VehicleType) &&
                (filter.VehicleColor == null || c.Vehicle!.Color == filter.VehicleColor) &&
                (filter.VehicleBrand == null || c.Vehicle!.Brand == filter.VehicleBrand) &&
                (filter.VehicleStatus == null || c.Vehicle!.Status == filter.VehicleStatus) &&
                (filter.VehicleFuelType == null || c.Vehicle!.FuelType == filter.VehicleFuelType) &&
                (filter.LineTimeDayType == null || c.LineTime!.DayType == filter.LineTimeDayType) &&
                (filter.EmployeeRole == null || c.EmployeeWorkday!.Employee!.Role == filter.EmployeeRole) &&
                (filter.EmployeeStatus == null || c.EmployeeWorkday!.Employee!.Status == filter.EmployeeStatus) &&
                (filter.LineDirectionType == null || c.LineTime!.Line!.DirectionType == filter.LineDirectionType) &&
                (filter.VehicleBusServiceType == null || c.Vehicle!.BusServiceType == filter.VehicleBusServiceType) &&
                (filter.LineTimeDirectionType == null || c.LineTime!.DirectionType == filter.LineTimeDirectionType) &&
                (filter.VehicleBusChassisBrand == null || c.Vehicle!.BusChassisBrand == filter.VehicleBusChassisBrand) &&
                (filter.EmployeeWorkDayDayType == null || c.EmployeeWorkday!.DayType == filter.EmployeeWorkDayDayType) &&
                (filter.EmployeeBloodType == null || c.EmployeeWorkday!.Employee!.BloodType == filter.EmployeeBloodType) &&
                (filter.VehicleTransmissionType == null || c.Vehicle!.TransmissionType == filter.VehicleTransmissionType) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.EmployeeWorkday!.Employee!.Name.ToLower().Contains(value) ||
                c.EmployeeWorkday!.Employee!.Code.ToLower().Contains(value) ||
                c.LineTime!.Line!.Mileage.ToString().Contains(value) ||
                c.LineTime!.Line!.Name.ToLower().Contains(value) ||
                c.LineTime!.Line!.Number.ToLower().Contains(value) ||
                c.Vehicle!.Prefix.ToLower().Contains(value) ||
                c.Vehicle!.Model.ToLower().Contains(value) ||
                c.Vehicle!.Plate.ToLower().Contains(value) ||
                c.Vehicle!.Renavam.ToLower().Contains(value) ||
                c.Vehicle!.Licensing!.ToLower().Contains(value) ||
                c.Vehicle!.NumberChassis!.ToLower().Contains(value) ||
                c.Vehicle!.BodyworkNumber!.ToLower().Contains(value) ||
                c.Vehicle!.BusChassisModel!.ToLower().Contains(value) ||
                c.Vehicle!.EngineNumber!.ToLower().Contains(value) ||
                c.EmployeeWorkday!.Employee!.Rg.ToLower().Contains(value) ||
                c.EmployeeWorkday!.Employee!.Cpf.ToLower().Contains(value) ||
                c.EmployeeWorkday!.Employee!.Phone.ToLower().Contains(value) ||
                c.EmployeeWorkday!.Employee!.CnhNumber!.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
