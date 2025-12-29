namespace Common.Logging.Extensions;

/// <summary> Класс с методом расширения для добавления Serilog логирования </summary>
public static class LoggingServiceCollectionExtensions
{
    public static IServiceCollection AddCommonLogging(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        
        services.AddSingleton(Log.Logger);
        services.AddLogging(builder => 
        {
            builder.ClearProviders();
            builder.AddSerilog();
        });
        return services;
    }
}
