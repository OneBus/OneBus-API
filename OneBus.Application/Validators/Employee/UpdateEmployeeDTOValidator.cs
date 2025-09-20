using FluentValidation;
using OneBus.Application.DTOs.Employee;
using OneBus.Application.Utils;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Employee;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Validators.Employee
{
    public class UpdateEmployeeDTOValidator : AbstractValidator<UpdateEmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeDTOValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty().OverridePropertyName("Nome");
            RuleFor(c => c.Rg).NotEmpty();

            RuleFor(c => c.Cpf).NotEmpty()
                .MustAsync(async (employee, cpf, ct) => !await CpfAlreadyExistsAsync(employee.Id, cpf, ct))
                .WithMessage(ErrorUtils.AlreadyExists("Cpf").Message);

            RuleFor(c => c.BloodType).Must(ValidationUtils.IsValidEnumValue<BloodType>)
                .OverridePropertyName("Tipo Sanguíneo");

            RuleFor(c => c.Code).NotEmpty()
                .MustAsync(async (employee, code, ct) => !await CodeAlreadyExistsAsync(employee.Id, code, ct))
                .OverridePropertyName("Matrícula")
                .WithMessage(ErrorUtils.AlreadyExists("Matrícula").Message);

            RuleFor(c => c.Role).Must(ValidationUtils.IsValidEnumValue<Role>)
                .OverridePropertyName("Cargo");

            RuleFor(c => c.Email).NotEmpty().EmailAddress()
                .MustAsync(async (employee, email, ct) => !await EmailAlreadyExistsAsync(employee.Id, email, ct))
                .WithMessage(ErrorUtils.AlreadyExists("Email").Message);

            RuleFor(c => c.Phone).NotEmpty()
                .MustAsync(async (employee, phone, ct) => !await PhoneAlreadyExistsAsync(employee.Id, phone, ct))
                .OverridePropertyName("Telefone")
                .WithMessage(ErrorUtils.AlreadyExists("Telefone").Message);

            RuleFor(c => c.CnhNumber)
                .MustAsync(async (employee, cnhNumber, ct) => !await CnhNumberAlreadyExistsAsync(employee.Id, cnhNumber, ct))
                .OverridePropertyName("Número da CNH")
                .WithMessage(ErrorUtils.AlreadyExists("Número da CNH").Message);
          
            RuleFor(c => c.Status).Must(ValidationUtils.IsValidEnumValue<EmployeeStatus>);
        }

        private async Task<bool> CpfAlreadyExistsAsync(long id, string cpf, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Cpf.ToLower().Equals(cpf) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> CodeAlreadyExistsAsync(long id, string code, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Code.ToLower().Equals(code) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> EmailAlreadyExistsAsync(long id, string email, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Email.ToLower().Equals(email) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> PhoneAlreadyExistsAsync(long id, string phone, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Phone.ToLower().Equals(phone) && c.Id != id,
                cancellationToken: cancellationToken);
        }

        private async Task<bool> CnhNumberAlreadyExistsAsync(long id, string? cnhNumber, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(cnhNumber))
                return false;

            return await _employeeRepository.AnyAsync(c => c.CnhNumber!.ToLower().Equals(cnhNumber) && c.Id != id,
                cancellationToken: cancellationToken);
        }
    }
}
