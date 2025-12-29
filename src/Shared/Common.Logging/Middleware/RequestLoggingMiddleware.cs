namespace Common.Logging.Middleware;

/// <summary> Класс middleware для логирования и снятия метрик о длительности выполнения http-запросов к API </summary>
public class RequestLoggingMiddleware(RequestDelegate _next, ILogger<RequestLoggingMiddleware> _logger)
{
    private readonly RequestDelegate next = _next;
    private readonly ILogger<RequestLoggingMiddleware> logger = _logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        // LogContext.PushProperty возвр. объект типа IDisposable, 
        // кот. представляет собой область видимости scope для добавленного с-ва
        using (LogContext.PushProperty("RequestId", context.TraceIdentifier))
        using (LogContext.PushProperty("Method", context.Request.Method))
        using (LogContext.PushProperty("Path", context.Request.Path))
        {
            logger.LogInformation("Начало обработки запроса {Method} {Path}",
            context.Request.Method, context.Request.Path);

            try
            {
                await next(context);
                stopwatch.Stop();

                using (LogContext.PushProperty("ResponseTime", stopwatch.ElapsedMilliseconds))
                using (LogContext.PushProperty("StatusCode", context.Response.StatusCode))
                {
                    logger.LogInformation("Запрос завершен за {ResponseTime}ms со статусом {StatusCode}",
                    stopwatch.ElapsedMilliseconds, context.Response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                using (LogContext.PushProperty("ResponseTime", stopwatch.ElapsedMilliseconds))
                using (LogContext.PushProperty("StatusCode", 500))
                {
                    logger.LogError(ex, "Ошибка при обработке запроса за {ResponseTime}ms",
                    stopwatch.ElapsedMilliseconds);
                    throw;
                }
            }
        }
    }
}
