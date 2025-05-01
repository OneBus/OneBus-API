using FluentValidation;
using OneBus.Domain.Models;

namespace OneBus.Application.Validators.Email
{
    public class EmailValidator : AbstractValidator<EmailModel>
    {
        public EmailValidator()
        {
            
        }
    }
}
