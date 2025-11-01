using FluentValidation;
using OneBus.Application.DTOs.Maintenance;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Maintenance;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.Maintenance
{
    public class CreateMaintenanceDTOValidator : AbstractValidator<CreateMaintenanceDTO>
    {
        private readonly IVehicleRepository _vehicleRepository;

        const string VehicleIdPropertyName = "Id do Veículo";

        public CreateMaintenanceDTOValidator(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;

            RuleFor(c => c.VehicleId).GreaterThan(0)
               .OverridePropertyName(VehicleIdPropertyName);

            RuleFor(c => c.VehicleId)
                .MustAsync(ExistsAsync)
                .WithMessage(ErrorUtils.EntityNotFound(VehicleIdPropertyName).Message)
                .OverridePropertyName(VehicleIdPropertyName);

            RuleFor(c => c.Description)
                .NotEmpty()
                .OverridePropertyName("Descrição");

            RuleFor(c => c.Cost).GreaterThanOrEqualTo(0)
              .OverridePropertyName("Custo");

            RuleFor(c => c.Sector)
                .Must(ValidationUtils.IsValidEnumValue<Sector>)
                .OverridePropertyName("Setor");          
        }

        private async Task<bool> ExistsAsync(long vehicleId, CancellationToken ct = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Id == vehicleId, cancellationToken: ct);
        }
    }
}
