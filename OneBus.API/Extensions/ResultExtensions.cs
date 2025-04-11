using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OneBus.Domain.Commons.Result;

namespace OneBus.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            return result switch
            {
                SuccessResult<T>  => new OkObjectResult(result),
                ConflictResult<T> => new ConflictObjectResult(result),
                NotFound<T>       => new NotFoundObjectResult(result),
                ErrorResult<T>    => new BadRequestObjectResult(result),
                InvalidResult<T>  => new UnprocessableEntityObjectResult(result),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
