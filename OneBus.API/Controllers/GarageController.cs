using OneBus.Application.DTOs.Garage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class GarageController : BaseController<Garage, CreateGarageDTO, ReadGarageDTO, UpdateGarageDTO, BaseFilter>
    {
        public GarageController(
            IBaseService<Garage, CreateGarageDTO, ReadGarageDTO, UpdateGarageDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
