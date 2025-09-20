using OneBus.Application.DTOs.EmployeeWorkday;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IEmployeeWorkdayService :
        IBaseService<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, EmployeeWorkDayFilter>
    {
        Result<IEnumerable<ReadDayTypeDTO>> GetDaysTypes();
    }
}
