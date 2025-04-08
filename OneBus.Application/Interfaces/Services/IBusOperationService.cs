using OneBus.Application.DTOs.BusOperation;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IBusOperationService : 
        IBaseService<BusOperation, CreateBusOperationDTO, ReadBusOperationDTO, UpdateBusOperationDTO, BaseFilter>
    {
    }
}
