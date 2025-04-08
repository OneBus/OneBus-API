using FluentValidation;
using OneBus.Application.DTOs.Bus;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class BusService : BaseService<Bus, CreateBusDTO, ReadBusDTO, UpdateBusDTO, BaseFilter>, IBusService
    {
        public BusService(
            IBaseRepository<Bus, BaseFilter> baseRepository, 
            IValidator<CreateBusDTO> createValidator, 
            IValidator<UpdateBusDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
