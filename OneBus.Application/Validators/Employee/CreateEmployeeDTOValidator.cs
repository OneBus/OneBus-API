using FluentValidation;
using OneBus.Application.DTOs.Employee;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Employee;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.Employee
{
    public class CreateEmployeeDTOValidator : AbstractValidator<CreateEmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeDTOValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(c => c.Name).NotEmpty().OverridePropertyName("Nome");
            RuleFor(c => c.Rg).NotEmpty();

            RuleFor(c => c.Cpf).NotEmpty()
                .MustAsync(async (cpf, ct) => !await CpfAlreadyExistsAsync(cpf, ct))
                .WithMessage(ErrorUtils.AlreadyExists("Cpf").Message);

            RuleFor(c => c.BloodType).Must(ValidationUtils.IsValidEnumValue<BloodType>)
                .OverridePropertyName("Tipo Sanguíneo");

            RuleFor(c => c.Code).NotEmpty()
                .MustAsync(async (code, ct) => !await CodeAlreadyExistsAsync(code, ct))
                .OverridePropertyName("Matrícula")
                .WithMessage(ErrorUtils.AlreadyExists("Matrícula").Message);

            RuleFor(c => c.Role).Must(ValidationUtils.IsValidEnumValue<Role>)
                .OverridePropertyName("Cargo");

            RuleFor(c => c.Email).NotEmpty().EmailAddress()
                .MustAsync(async (email, ct) => !await EmailAlreadyExistsAsync(email, ct))
                .WithMessage(ErrorUtils.AlreadyExists("Email").Message);

            RuleFor(c => c.Phone).NotEmpty()
                .MustAsync(async (phone, ct) => !await PhoneAlreadyExistsAsync(phone, ct))
                .OverridePropertyName("Telefone")
                .WithMessage(ErrorUtils.AlreadyExists("Telefone").Message);

            RuleFor(c => c.CnhNumber)
                .MustAsync(async (cnhNumber, ct) => !await CnhNumberAlreadyExistsAsync(cnhNumber, ct))
                .OverridePropertyName("Número da CNH")
                .WithMessage(ErrorUtils.AlreadyExists("Número da CNH").Message);
            
            RuleFor(c => c.Status).Must(ValidationUtils.IsValidEnumValue<EmployeeStatus>);
        }

        private async Task<bool> CpfAlreadyExistsAsync(string cpf, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Cpf.ToLower().Equals(cpf),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> CodeAlreadyExistsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Code.ToLower().Equals(code),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> EmailAlreadyExistsAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Email.ToLower().Equals(email),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> PhoneAlreadyExistsAsync(string phone, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.AnyAsync(c => c.Phone.ToLower().Equals(phone),
                cancellationToken: cancellationToken);
        }

        private async Task<bool> CnhNumberAlreadyExistsAsync(string? cnhNumber, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(cnhNumber))
                return false;

            return await _employeeRepository.AnyAsync(c => c.CnhNumber!.ToLower().Equals(cnhNumber),
                cancellationToken: cancellationToken);
        }
    }
}
