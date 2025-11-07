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
        private readonly IVehicleOperationRepository _vehicleOperationRepository;

        public UpdateVehicleOperationDTOValidator(
            IVehicleRepository vehicleRepository,
            ILineTimeRepository lineTimeRepository,
            IEmployeeWorkdayRepository employeeWorkdayRepository,
            IVehicleOperationRepository vehicleOperationRepository)
        {
            _vehicleRepository = vehicleRepository;
            _lineTimeRepository = lineTimeRepository;
            _employeeWorkdayRepository = employeeWorkdayRepository;
            _vehicleOperationRepository = vehicleOperationRepository;

            RuleFor(c => c.Id).GreaterThan(0);

            RuleFor(c => c.VehicleId)
                .MustAsync(IsValidVehicleAsync)
                .WithMessage(CreateVehicleOperationDTOValidator.InvalidVehicle)
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

        private async Task<bool> IsValidVehicleAsync(
             UpdateVehicleOperationDTO vehicleOperation,
             long vehicleId,
             CancellationToken cancellationToken = default)
        {
            var vehicleExists = await _vehicleRepository.AnyAsync(c => c.Id == vehicleId, cancellationToken: cancellationToken);

            if (!vehicleExists)
                return false;

            return !await _vehicleOperationRepository.AnyAsync(c => c.VehicleId == vehicleOperation.VehicleId &&
                                                                    c.LineTimeId == vehicleOperation.LineTimeId &&
                                                                    c.Id != vehicleOperation.Id,
                                                               cancellationToken: cancellationToken);
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
