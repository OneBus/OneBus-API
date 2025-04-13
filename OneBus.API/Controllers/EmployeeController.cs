using OneBus.Application.DTOs.Employee;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class EmployeeController : BaseController<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, BaseFilter>
    {
        public EmployeeController(
            IBaseService<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
