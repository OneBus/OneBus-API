using OneBus.Application.DTOs.Maintenance;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IMaintenanceService :
        IBaseService<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, MaintenanceFilter>
    {
        Result<IEnumerable<ReadSectorDTO>> GetSectors();
    }
}
