using FluentValidation;
using OneBus.Application.DTOs.Company;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class CompanyService : BaseService<Company, CreateCompanyDTO, ReadCompanyDTO, UpdateCompanyDTO, BaseFilter>,
        ICompanyService
    {
        public CompanyService(
            IBaseRepository<Company, BaseFilter> baseRepository, 
            IValidator<CreateCompanyDTO> createValidator, 
            IValidator<UpdateCompanyDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
