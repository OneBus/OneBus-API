using OneBus.Application.DTOs.EmployeeWorkday;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class EmployeeWorkdayController : BaseController<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, BaseFilter>
    {
        public EmployeeWorkdayController(
            IBaseService<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
