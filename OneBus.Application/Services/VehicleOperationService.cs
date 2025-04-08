using FluentValidation;
using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class VehicleOperationService : BaseService<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, BaseFilter>,
        IVehicleOperationService
    {
        public VehicleOperationService(
            IBaseRepository<VehicleOperation, BaseFilter> baseRepository, 
            IValidator<CreateVehicleOperationDTO> createValidator, 
            IValidator<UpdateVehicleOperationDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
