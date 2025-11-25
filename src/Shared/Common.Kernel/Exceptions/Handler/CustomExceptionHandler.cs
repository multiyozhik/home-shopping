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
        var (title, detail, statusCode) = exception switch
        {
            NotFoundException notFoundException => (
                "Ресурс не найден",
                notFoundException.Message,
                StatusCodes.Status404NotFound
            ),
            _ => (
                "Внутренняя ошибка сервера", 
                "Произошла непредвиденная ошибка", 
                StatusCodes.Status500InternalServerError)
        };
        
        httpContext.Response.StatusCode = statusCode;

        var problemsDetails = new ProblemDetails()
        {
            Title = title,
            Detail = detail,
            Status = statusCode,
            Instance = httpContext.Request.Path 
        };

        problemsDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);
        problemsDetails.Extensions.Add("errorMessage", exception.Message);

        await httpContext.Response.WriteAsJsonAsync(problemsDetails, token);

        return true;
    }
}