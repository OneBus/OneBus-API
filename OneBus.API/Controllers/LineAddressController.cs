using OneBus.Application.DTOs.LineAddress;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class LineAddressController : BaseController<LineAddress, CreateLineAddressDTO, ReadLineAddressDTO, UpdateLineAddressDTO, BaseFilter>
    {
        public LineAddressController(
            IBaseService<LineAddress, CreateLineAddressDTO, ReadLineAddressDTO, UpdateLineAddressDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
