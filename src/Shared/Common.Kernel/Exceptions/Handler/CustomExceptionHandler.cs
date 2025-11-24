using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Kernel.Exceptions.Handler;

/// <summary> Глобальный обработчик исключений </summary>
public class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken token)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var problemsDetails = new ProblemDetails()
        {
            Title = "",
            Detail = "",
            Status = StatusCodes.Status500InternalServerError,
            Instance = httpContext.Request.Path 
        };

        problemsDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);
        problemsDetails.Extensions.Add("errorMessage", exception.Message);

        await httpContext.Response.WriteAsJsonAsync(problemsDetails, token);

        return true;
    }
}