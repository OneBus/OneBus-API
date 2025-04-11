using FluentValidation.Results;
using OneBus.Domain.Commons;

namespace OneBus.Application.Extensions
{
    public static class ResultExtensions
    {
        public static IEnumerable<Error> ToErrors(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(c => new Error(c.ErrorMessage, c.PropertyName));
        }
    }
}
