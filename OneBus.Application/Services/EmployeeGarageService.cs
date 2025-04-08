using FluentValidation;
using OneBus.Application.DTOs.EmployeeGarage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class EmployeeGarageService : BaseService<EmployeeGarage, CreateEmployeeGarageDTO, ReadEmployeeGarageDTO, UpdateEmployeeGarageDTO, BaseFilter>,
        IEmployeeGarageService
    {
        public EmployeeGarageService(
            IBaseRepository<EmployeeGarage, BaseFilter> baseRepository, 
            IValidator<CreateEmployeeGarageDTO> createValidator, 
            IValidator<UpdateEmployeeGarageDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
