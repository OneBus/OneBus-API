using FluentValidation;
using OneBus.Domain.Commons;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Application.DTOs.VehicleOperation;

namespace OneBus.Application.Validators.VehicleOperation
{
    public class UpdateVehicleOperationDTOValidator : AbstractValidator<UpdateVehicleOperationDTO>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILineTimeRepository _lineTimeRepository;
        private readonly IEmployeeWorkdayRepository _employeeWorkdayRepository;       

        public UpdateVehicleOperationDTOValidator(
            IVehicleRepository vehicleRepository,
            ILineTimeRepository lineTimeRepository,
            IEmployeeWorkdayRepository employeeWorkdayRepository)
        {
            _vehicleRepository = vehicleRepository;
            _lineTimeRepository = lineTimeRepository;
            _employeeWorkdayRepository = employeeWorkdayRepository;

            RuleFor(c => c.Id).GreaterThan(0);

            RuleFor(c => c.VehicleId)
                .MustAsync(VehicleExistsAsync)
                .WithMessage(ErrorUtils.EntityNotFound(CreateVehicleOperationDTOValidator.VehicleIdPropertyName).Message)
                .OverridePropertyName(CreateVehicleOperationDTOValidator.VehicleIdPropertyName);

            RuleFor(c => c.LineTimeId)
               .MustAsync(LineTimeExistsAsync)
               .WithMessage(ErrorUtils.EntityNotFound(CreateVehicleOperationDTOValidator.LineTimeIdPropertyName).Message)
               .OverridePropertyName(CreateVehicleOperationDTOValidator.LineTimeIdPropertyName);

            RuleFor(c => c.EmployeeWorkdayId)
              .MustAsync(EmployeeWorkdayExistsAsync)
              .WithMessage(ErrorUtils.EntityNotFound(CreateVehicleOperationDTOValidator.EmployeeWorkdayIdPropertyName).Message)
              .OverridePropertyName(CreateVehicleOperationDTOValidator.EmployeeWorkdayIdPropertyName);
        }

        private async Task<bool> VehicleExistsAsync(long vehicleId, CancellationToken ct = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Id == vehicleId, cancellationToken: ct);
        }

        private async Task<bool> LineTimeExistsAsync(long lineTimeId, CancellationToken ct = default)
        {
            return await _lineTimeRepository.AnyAsync(c => c.Id == lineTimeId, cancellationToken: ct);
        }

        private async Task<bool> EmployeeWorkdayExistsAsync(long employeeWorkdayId, CancellationToken ct = default)
        {
            return await _employeeWorkdayRepository.AnyAsync(c => c.Id == employeeWorkdayId, cancellationToken: ct);
        }
    }
}
