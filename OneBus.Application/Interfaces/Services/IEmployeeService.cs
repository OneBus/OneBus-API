using OneBus.Application.DTOs.Employee;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IEmployeeService : 
        IBaseService<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, BaseFilter>
    {
    }
}
