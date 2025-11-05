using OneBus.Application.DTOs.Dashboard;
using OneBus.Domain.Commons.Result;

namespace OneBus.Application.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<Result<ReadEmployeeTotalCountDTO>> GetEmployeeStatusAsync(CancellationToken cancellationToken = default);
        
        Task<Result<ReadVehicleTotalCountDTO>> GetVehicleStatusAsync(CancellationToken cancellationToken = default);
    }
}
