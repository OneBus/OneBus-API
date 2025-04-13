using OneBus.Application.DTOs.EmployeeGarage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class EmployeeGarageController : BaseController<EmployeeGarage, CreateEmployeeGarageDTO, ReadEmployeeGarageDTO, UpdateEmployeeGarageDTO, BaseFilter>
    {
        public EmployeeGarageController(
            IBaseService<EmployeeGarage, CreateEmployeeGarageDTO, ReadEmployeeGarageDTO, UpdateEmployeeGarageDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
