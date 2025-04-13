using OneBus.Application.DTOs.Company;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class CompanyController : BaseController<Company, CreateCompanyDTO, ReadCompanyDTO, UpdateCompanyDTO, BaseFilter>
    {
        public CompanyController(
            IBaseService<Company, CreateCompanyDTO, ReadCompanyDTO, UpdateCompanyDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
