using OneBus.Application.DTOs.EmployeeGarage;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IEmployeeGarageService : 
        IBaseService<EmployeeGarage, CreateEmployeeGarageDTO, ReadEmployeeGarageDTO, UpdateEmployeeGarageDTO, BaseFilter>
    {
    }
}
