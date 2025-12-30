namespace Common.Logging.Extensions;

/// <summary> Класс с методом расширения для добавления Serilog логирования </summary>
public static class LoggingServiceCollectionExtensions
{
    public static IServiceCollection AddCommonLogging(this IServiceCollection services, IConfiguration configuration)
    {
        var elasticUri = configuration.GetSection("ElasticConfiguration:Uri").Value!;
        var serviceName = Assembly.GetEntryAssembly()?
            .GetName().Name ?? "Unknown";

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
            {
                IndexFormat = "homeshopping-logs-{0:yyyy.MM.dd}",
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                TemplateName = "homeshopping-template",
                NumberOfShards = 1,
                NumberOfReplicas = 0
            })
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ServiceName", serviceName)
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
