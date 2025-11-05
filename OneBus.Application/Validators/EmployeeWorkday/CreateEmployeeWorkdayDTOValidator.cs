using FluentValidation;
using OneBus.Application.DTOs.EmployeeWorkday;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.EmployeeWorkday
{
    public class CreateEmployeeWorkdayDTOValidator : AbstractValidator<CreateEmployeeWorkdayDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;

        const string EmployeeIdPropertyName = "Id do Funcionário";

        public CreateEmployeeWorkdayDTOValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(c => c.EmployeeId).GreaterThan(0)
                .OverridePropertyName(EmployeeIdPropertyName);

            RuleFor(c => c.EmployeeId)
                .MustAsync(ExistsAsync)
                .WithMessage(ErrorUtils.EntityNotFound(EmployeeIdPropertyName).Message)
                .OverridePropertyName(EmployeeIdPropertyName);

            RuleFor(c => c.DayType).Must(ValidationUtils.IsValidEnumValue<DayType>)
               .OverridePropertyName("Dia da Semana");            
        }

        private async Task<bool> ExistsAsync(long employeeId, CancellationToken ct = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Id == employeeId, cancellationToken: ct);
        }
    }
}
