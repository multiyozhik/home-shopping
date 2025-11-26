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
            ValidationException validationException => (
                "Ошибка валидации",
                validationException.Message,
                StatusCodes.Status400BadRequest
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

        if (exception is ValidationException fvException)
        {
            var errors = fvException.Errors?
                .Select(x => new {x.PropertyName, x.ErrorMessage}).ToList();

            if (errors is not null && errors.Count > 0)
            {
                problemsDetails.Extensions.Add("validationException", errors);
            }
        } 
        else
        {
            problemsDetails.Extensions.Add("errorMessage", exception.Message);
        }

        await httpContext.Response.WriteAsJsonAsync(problemsDetails, token);

        return true;
    }
}