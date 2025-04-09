using FluentValidation;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class VehicleService : BaseService<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter>,
        IVehicleService
    {
        public VehicleService(
            IBaseRepository<Vehicle, BaseFilter> baseRepository, 
            IValidator<CreateVehicleDTO> createValidator, 
            IValidator<UpdateVehicleDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(Vehicle entity, UpdateVehicleDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
