using FluentValidation;
using OneBus.Application.DTOs.Garage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class GarageService : BaseService<Garage, CreateGarageDTO, ReadGarageDTO, UpdateGarageDTO, BaseFilter>,
        IGarageService
    {
        public GarageService(
            IBaseRepository<Garage, BaseFilter> baseRepository, 
            IValidator<CreateGarageDTO> createValidator, 
            IValidator<UpdateGarageDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
