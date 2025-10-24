using FluentValidation;
using OneBus.Application.DTOs.Maintenance;
using OneBus.Domain.Enums.Maintenance;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.Maintenance
{
    public class UpdateMaintenanceDTOValidator : AbstractValidator<UpdateMaintenanceDTO>
    {
        public UpdateMaintenanceDTOValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);

            RuleFor(c => c.Description)
               .NotEmpty()
               .OverridePropertyName("Descrição");

            RuleFor(c => c.Cost).GreaterThanOrEqualTo(0)
              .OverridePropertyName("Custo");

            RuleFor(c => c.Sector)
                .Must(ValidationUtils.IsValidEnumValue<Sector>)
                .OverridePropertyName("Setor");

            RuleFor(c => c.EndDate)
               .Must((dto, endTime) => endTime >= dto.StartDate)
               .WithMessage("Horário inválido")
               .OverridePropertyName("Horário de Término");
        }
    }
}
