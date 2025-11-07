using FluentValidation;
using OneBus.Domain.Commons;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Application.DTOs.VehicleOperation;

namespace OneBus.Application.Validators.VehicleOperation
{
    public class CreateVehicleOperationDTOValidator : AbstractValidator<CreateVehicleOperationDTO>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILineTimeRepository _lineTimeRepository;
        private readonly IEmployeeWorkdayRepository _employeeWorkdayRepository;
        private readonly IVehicleOperationRepository _vehicleOperationRepository;

        public const string VehicleIdPropertyName = "Id do Veículo";
        public const string LineTimeIdPropertyName = "Id do Horário Linha";
        public const string EmployeeWorkdayIdPropertyName = "Id do Horário Funcionário";
        public const string InvalidVehicle = "Veículo não existe ou já está associado a esse Horário da Linha";

        public CreateVehicleOperationDTOValidator(
            IVehicleRepository vehicleRepository,
            ILineTimeRepository lineTimeRepository,
            IEmployeeWorkdayRepository employeeWorkdayRepository,
            IVehicleOperationRepository vehicleOperationRepository)
        {
            _vehicleRepository = vehicleRepository;
            _lineTimeRepository = lineTimeRepository;
            _employeeWorkdayRepository = employeeWorkdayRepository;
            _vehicleOperationRepository = vehicleOperationRepository;

            RuleFor(c => c.VehicleId)
                .MustAsync(IsValidVehicleAsync)
                .WithMessage(InvalidVehicle)
                .OverridePropertyName(VehicleIdPropertyName);

            RuleFor(c => c.LineTimeId)
               .MustAsync(LineTimeExistsAsync)
               .WithMessage(ErrorUtils.EntityNotFound(LineTimeIdPropertyName).Message)
               .OverridePropertyName(LineTimeIdPropertyName);

            RuleFor(c => c.EmployeeWorkdayId)
              .MustAsync(EmployeeWorkdayExistsAsync)
              .WithMessage(ErrorUtils.EntityNotFound(EmployeeWorkdayIdPropertyName).Message)
              .OverridePropertyName(EmployeeWorkdayIdPropertyName);
        }

        private async Task<bool> IsValidVehicleAsync(
            CreateVehicleOperationDTO vehicleOperation,
            long vehicleId,
            CancellationToken cancellationToken = default)
        {
            var vehicleExists = await _vehicleRepository.AnyAsync(c => c.Id == vehicleId, cancellationToken: cancellationToken);

            if (!vehicleExists)
                return false;

            return !await _vehicleOperationRepository.AnyAsync(c => c.VehicleId == vehicleOperation.VehicleId &&
                                                                    c.LineTimeId == vehicleOperation.LineTimeId,
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
