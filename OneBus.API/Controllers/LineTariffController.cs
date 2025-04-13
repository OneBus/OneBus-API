using OneBus.Application.DTOs.LineTariff;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class LineTariffController : BaseController<LineTariff, CreateLineTariffDTO, ReadLineTariffDTO, UpdateLineTariffDTO, BaseFilter>
    {
        public LineTariffController(
            IBaseService<LineTariff, CreateLineTariffDTO, ReadLineTariffDTO, UpdateLineTariffDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
