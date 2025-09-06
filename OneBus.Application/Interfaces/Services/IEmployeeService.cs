using OneBus.Application.DTOs.Employee;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IEmployeeService :
        IBaseService<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, EmployeeFilter>
    {
        Result<IEnumerable<ReadBloodTypeDTO>> GetBloodTypes();
        
        Result<IEnumerable<ReadCnhCategoryDTO>> GetCnhCategories();
        
        Result<IEnumerable<ReadRoleDTO>> GetRoles();
        
        Result<IEnumerable<ReadStatusDTO>> GetStatus();
    }
}
