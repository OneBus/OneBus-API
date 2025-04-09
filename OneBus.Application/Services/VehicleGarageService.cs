using FluentValidation;
using OneBus.Application.DTOs.VehicleGarage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class VehicleGarageService : BaseService<VehicleGarage, CreateVehicleGarageDTO, ReadVehicleGarageDTO, UpdateVehicleGarageDTO, BaseFilter>,
        IVehicleGarageService
    {
        public VehicleGarageService(
            IBaseRepository<VehicleGarage, BaseFilter> baseRepository, 
            IValidator<CreateVehicleGarageDTO> createValidator, 
            IValidator<UpdateVehicleGarageDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(VehicleGarage entity, UpdateVehicleGarageDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
