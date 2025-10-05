using FluentValidation;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Utils;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Validators.Vehicle
{
    public class UpdateVehicleDTOValidator : AbstractValidator<UpdateVehicleDTO>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleDTOValidator(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;

            RuleFor(c => c.Id).GreaterThan(0);

            RuleFor(c => c.Prefix)
               .MustAsync(async (vehicle, prefix, ct) => !await IsPrefixInUseAsync(vehicle.Id, prefix, ct))
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
              .MustAsync(async (vehicle, plate, ct) => !await IsPlateInUseAsync(vehicle.Id, plate, ct))
              .WithMessage(ErrorUtils.AlreadyExists("Placa").Message)
              .NotEmpty()
              .OverridePropertyName("Placa");

            RuleFor(c => c.Renavam)
             .MustAsync(async (vehicle, renavam, ct) => !await IsRenavamInUseAsync(vehicle.Id, renavam, ct))
             .When(c => !string.IsNullOrWhiteSpace(c.Renavam))
             .WithMessage(ErrorUtils.AlreadyExists("Renavam").Message)
             .OverridePropertyName("Renavam");

            RuleFor(c => c.NumberChassis)
            .MustAsync(async (vehicle, numberChassis, ct) => !await IsNumberChassisInUseAsync(vehicle.Id, numberChassis, ct))
            .When(c => !string.IsNullOrWhiteSpace(c.NumberChassis))
            .WithMessage(ErrorUtils.AlreadyExists("Número do Chassi").Message)
            .OverridePropertyName("Número do Chassi");

            RuleFor(c => c.BodyworkNumber)
            .MustAsync(async (vehicle, bodyworkNumber, ct) => !await IsBodyworkNumberInUseAsync(vehicle.Id, bodyworkNumber, ct))
            .When(c => !string.IsNullOrWhiteSpace(c.BodyworkNumber))
            .WithMessage(ErrorUtils.AlreadyExists("Número da Carroceria").Message)
            .OverridePropertyName("Número da Carroceria");

            RuleFor(c => c.EngineNumber)
            .MustAsync(async (vehicle, engineNumber, ct) => !await IsEngineNumberInUseAsync(vehicle.Id, engineNumber, ct))
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

        private async Task<bool> IsPrefixInUseAsync(long id, string prefix, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Prefix.ToLower().Equals(prefix) && c.Status != (byte)VehicleStatus.Desativado && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsPlateInUseAsync(long id, string plate, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Plate.ToLower().Equals(plate) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsRenavamInUseAsync(long id, string renavam, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => c.Renavam.ToLower().Equals(renavam) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsNumberChassisInUseAsync(long id, string? numberChassis, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => !string.IsNullOrWhiteSpace(c.NumberChassis) && c.NumberChassis.ToLower().Equals(numberChassis) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsBodyworkNumberInUseAsync(long id, string? bodyworkNumber, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => !string.IsNullOrWhiteSpace(c.BodyworkNumber) && c.BodyworkNumber.ToLower().Equals(bodyworkNumber) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> IsEngineNumberInUseAsync(long id, string? engineNumber, CancellationToken cancellationToken = default)
        {
            return await _vehicleRepository.AnyAsync(c => !string.IsNullOrWhiteSpace(c.EngineNumber) && c.EngineNumber.ToLower().Equals(engineNumber) && c.Id != id,
                cancellationToken: cancellationToken);
        }
    }
}
