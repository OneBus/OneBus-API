using FluentValidation.Results;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;

namespace OneBus.Application.Extensions
{
    public static class ResultExtensions
    {
        public static InvalidResult<T> ToInvalidResult<T>(this ValidationFailure validationFailure)
        {
            return InvalidResult<T>.Create(new Error(validationFailure.ErrorMessage, validationFailure.PropertyName));
        }

        public static InvalidResult<T> ToInvalidResult<T>(this List<ValidationFailure> validationFailures)
        {
            return InvalidResult<T>.Create(validationFailures.Select(c => new Error(c.ErrorMessage, c.PropertyName)));
        }
    }
}
