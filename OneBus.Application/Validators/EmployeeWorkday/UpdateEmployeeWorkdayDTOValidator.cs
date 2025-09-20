using FluentValidation;
using OneBus.Application.DTOs.EmployeeWorkday;

namespace OneBus.Application.Validators.EmployeeWorkday
{
    public class UpdateEmployeeWorkdayDTOValidator : AbstractValidator<UpdateEmployeeWorkdayDTO>
    {        
        public UpdateEmployeeWorkdayDTOValidator()
        {
            RuleFor(c => c.EndTime)
                .Must((dto, endTime) => endTime > dto.StartTime)
                .WithMessage("Horário inválido")
                .OverridePropertyName("Horário de Saída");
        }
    }
}
