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

        public const string VehicleIdPropertyName = "Id do Veículo";
        public const string LineTimeIdPropertyName = "Id do Horário Linha";
        public const string EmployeeWorkdayIdPropertyName = "Id do Horário Funcionário";

        public CreateVehicleOperationDTOValidator(
            IVehicleRepository vehicleRepository, 
            ILineTimeRepository lineTimeRepository, 
            IEmployeeWorkdayRepository employeeWorkdayRepository)
        {
            _vehicleRepository = vehicleRepository;
            _lineTimeRepository = lineTimeRepository;
            _employeeWorkdayRepository = employeeWorkdayRepository;

            RuleFor(c => c.VehicleId)
                .MustAsync(VehicleExistsAsync)
                .WithMessage(ErrorUtils.EntityNotFound(VehicleIdPropertyName).Message)
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
