using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OneBus.API.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails = new()
            {
                Title = "Erro do servidor.",
                Instance = httpContext.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
                Detail = "Desculpe mas um erro inesperado ocorreu."
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
            return true;
        }
    }
}
