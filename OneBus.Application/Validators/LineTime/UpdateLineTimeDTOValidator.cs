using FluentValidation;
using OneBus.Application.DTOs.LineTime;
using OneBus.Domain.Enums;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.LineTime
{
    public class UpdateLineTimeDTOValidator : AbstractValidator<UpdateLineTimeDTO>
    {        
        public UpdateLineTimeDTOValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
           
            RuleFor(c => c.DayType).Must(ValidationUtils.IsValidEnumValue<DayType>)
              .OverridePropertyName("Dia da Semana");
        }        
    }
}
