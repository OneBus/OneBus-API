using FluentValidation;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

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

            RuleFor(c => c.Licensing)
              .NotEmpty()
              .OverridePropertyName("Licenciamento");

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

            RuleFor(c => c.Color)
              .Must(ValidationUtils.IsValidEnumValue<Color>)
              .When(c => c.Color != null)
              .OverridePropertyName("Cor");

            RuleFor(c => c.TransmissionType)
             .Must(ValidationUtils.IsValidEnumValue<TransmissionType>)
             .OverridePropertyName("Tipo de Transmissão");

            RuleFor(c => c.BusServiceType)
               .Must(ValidationUtils.IsValidEnumValue<BusServiceType>)
               .When(c => c.BusServiceType != null)
               .OverridePropertyName("Tipo de Serviço");

            RuleFor(c => c.BusChassisBrand)
               .Must(ValidationUtils.IsValidEnumValue<BusChassisBrands>)
               .When(c => c.BusChassisBrand != null)
               .OverridePropertyName("Marca do Chassi");

            RuleFor(c => c.BusChassisModel)
               .NotEmpty()
               .When(c => c.BusChassisModel != null)
               .OverridePropertyName("Modelo do Chassi");

            RuleFor(c => c.BusChassisYear)
               .NotNull()
               .When(c => c.BusChassisYear != null)
               .OverridePropertyName("Ano do Chassi");

            RuleFor(c => c.BusHasLowFloor)
               .NotNull()
               .When(c => c.BusHasLowFloor != null)
               .OverridePropertyName("Possui Piso Baixo");

            RuleFor(c => c.BusHasLeftDoors)
               .NotNull()
               .When(c => c.BusHasLeftDoors != null)
               .OverridePropertyName("Possui Portas a Esquerda");

            RuleFor(c => c.BusInsuranceExpiration)
               .NotNull()
               .When(c => c.BusInsuranceExpiration != null)
               .OverridePropertyName("Vencimento do Seguro");
        }

        private async Task<bool> IsPrefixInUseAsync(string prefix, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Prefix.ToLower().Equals(prefix.ToLower()) && c.Status != (byte)VehicleStatus.Desativado,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsPlateInUseAsync(string plate, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Plate.ToLower().Equals(plate.ToLower()),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsRenavamInUseAsync(string renavam, CancellationToken cancellationToken = default)
        {            
            return await _vehicleRepository.AnyAsync(c => c.Renavam.ToLower().Equals(renavam.ToLower()),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsNumberChassisInUseAsync(string? numberChassis, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(numberChassis))
                return false;

            return await _vehicleRepository.AnyAsync(c => c.NumberChassis!.ToLower().Equals(numberChassis.ToLower()),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsBodyworkNumberInUseAsync(string? bodyworkNumber, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(bodyworkNumber))
                return false;

            return await _vehicleRepository.AnyAsync(c => c.BodyworkNumber!.ToLower().Equals(bodyworkNumber.ToLower()),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsEngineNumberInUseAsync(string? engineNumber, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(engineNumber))
                return false;

            return await _vehicleRepository.AnyAsync(c => c.EngineNumber!.ToLower().Equals(engineNumber.ToLower()),
                cancellationToken: cancellationToken);
        }
    }
}
