using OneBus.Application.DTOs.Maintenance;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IMaintenanceService : 
        IBaseService<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, BaseFilter>
    {
    }
}
