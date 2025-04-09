using FluentValidation;
using OneBus.Application.DTOs.Employee;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class EmployeeService : BaseService<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, BaseFilter>,
        IEmployeeService
    {
        public EmployeeService(
            IBaseRepository<Employee, BaseFilter> baseRepository, 
            IValidator<CreateEmployeeDTO> createValidator, 
            IValidator<UpdateEmployeeDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(Employee entity, UpdateEmployeeDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
