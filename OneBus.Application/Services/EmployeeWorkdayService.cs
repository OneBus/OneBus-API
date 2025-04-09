using FluentValidation;
using OneBus.Application.DTOs.EmployeeWorkday;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class EmployeeWorkdayService : BaseService<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, BaseFilter>,
        IEmployeeWorkdayService
    {
        public EmployeeWorkdayService(
            IBaseRepository<EmployeeWorkday, BaseFilter> baseRepository, 
            IValidator<CreateEmployeeWorkdayDTO> createValidator, 
            IValidator<UpdateEmployeeWorkdayDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(EmployeeWorkday entity, UpdateEmployeeWorkdayDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
