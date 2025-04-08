using OneBus.Application.DTOs.Company;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface ICompanyService : 
        IBaseService<Company, CreateCompanyDTO, ReadCompanyDTO, UpdateCompanyDTO, BaseFilter>
    {
    }
}
