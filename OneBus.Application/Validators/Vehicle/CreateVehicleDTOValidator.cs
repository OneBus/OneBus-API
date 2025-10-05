using FluentValidation;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Utils;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Validators.Vehicle
{
    public class CreateVehicleDTOValidator : AbstractValidator<CreateVehicleDTO>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleDTOValidator(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;

            RuleFor(c => c.Type)
                .Must(ValidationUtils.IsValidEnumValue<VehicleType>)
                .OverridePropertyName("Tipo");

            RuleFor(c => c.Prefix)
               .MustAsync(async (prefix, ct) => !await IsPrefixInUseAsync(prefix, ct))
               .WithMessage(ErrorUtils.AlreadyExists("Prefixo").Message)
               .NotEmpty()
               .OverridePropertyName("Prefixo");

            RuleFor(c => c.FuelType)
               .Must(ValidationUtils.IsValidEnumValue<FuelType>)
               .OverridePropertyName("Tipo de Combustível");

            RuleFor(c => c.Brand)
               .Must(ValidationUtils.IsValidEnumValue<VehicleBrands>)
               .OverridePropertyName("Marca");

            RuleFor(c => c.Model)
               .NotEmpty()
               .OverridePropertyName("Modelo");

            RuleFor(c => c.Plate)
              .MustAsync(async (plate, ct) => !await IsPlateInUseAsync(plate, ct))
              .WithMessage(ErrorUtils.AlreadyExists("Placa").Message)
              .NotEmpty()
              .OverridePropertyName("Placa");

            RuleFor(c => c.Renavam)
             .MustAsync(async (renavam, ct) => !await IsRenavamInUseAsync(renavam, ct))
             .When(c => !string.IsNullOrWhiteSpace(c.Renavam))
             .WithMessage(ErrorUtils.AlreadyExists("Renavam").Message)
             .OverridePropertyName("Renavam");

            RuleFor(c => c.NumberChassis)
            .MustAsync(async (numberChassis, ct) => !await IsNumberChassisInUseAsync(numberChassis, ct))
            .When(c => !string.IsNullOrWhiteSpace(c.NumberChassis))
            .WithMessage(ErrorUtils.AlreadyExists("Número do Chassi").Message)
            .OverridePropertyName("Número do Chassi");

            RuleFor(c => c.BodyworkNumber)
            .MustAsync(async (bodyworkNumber, ct) => !await IsBodyworkNumberInUseAsync(bodyworkNumber, ct))
            .When(c => !string.IsNullOrWhiteSpace(c.BodyworkNumber))
            .WithMessage(ErrorUtils.AlreadyExists("Número da Carroceria").Message)
            .OverridePropertyName("Número da Carroceria");

            RuleFor(c => c.EngineNumber)
            .MustAsync(async (engineNumber, ct) => !await IsEngineNumberInUseAsync(engineNumber, ct))
            .When(c => !string.IsNullOrWhiteSpace(c.EngineNumber))
            .WithMessage(ErrorUtils.AlreadyExists("Número do Motor").Message)
            .OverridePropertyName("Número do Motor");

            RuleFor(c => c.Status)
               .Must(ValidationUtils.IsValidEnumValue<VehicleStatus>)
               .OverridePropertyName("Status");

            RuleFor(c => c.BusServiceType)
               .Must(ValidationUtils.IsValidEnumValue<BusServiceType>)
               .OverridePropertyName("Tipo de Serviço");

            RuleFor(c => c.BusChassisBrand)
               .Must(ValidationUtils.IsValidEnumValue<BusChassisBrands>)
               .OverridePropertyName("Marca do Chassi");

            RuleFor(c => c.BusChassisModel)
               .NotEmpty()
               .OverridePropertyName("Modelo do Chassi");

            RuleFor(c => c.Color)
              .Must(ValidationUtils.IsValidEnumValue<Color>)
              .When(c => c.Color != null)
              .OverridePropertyName("Cor");

            RuleFor(c => c.TransmissionType)
             .Must(ValidationUtils.IsValidEnumValue<TransmissionType>)
             .OverridePropertyName("Tipo de Transmissão");
        }

        private async Task<bool> IsPrefixInUseAsync(string prefix, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Prefix.ToLower().Equals(prefix) && c.Status != (byte)VehicleStatus.Desativado,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsPlateInUseAsync(string plate, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Plate.ToLower().Equals(plate),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsRenavamInUseAsync(string renavam, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Renavam.ToLower().Equals(renavam),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsNumberChassisInUseAsync(string? numberChassis, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => !string.IsNullOrWhiteSpace(c.NumberChassis) && c.NumberChassis.ToLower().Equals(numberChassis),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsBodyworkNumberInUseAsync(string? bodyworkNumber, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => !string.IsNullOrWhiteSpace(c.BodyworkNumber) && c.BodyworkNumber.ToLower().Equals(bodyworkNumber),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsEngineNumberInUseAsync(string? engineNumber, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => !string.IsNullOrWhiteSpace(c.EngineNumber) && c.EngineNumber.ToLower().Equals(engineNumber),
                cancellationToken: cancellationToken);
        }
    }
}
