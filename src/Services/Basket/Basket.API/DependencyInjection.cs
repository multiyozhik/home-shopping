namespace Basket.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCarter();

        var assembly = typeof(Program).Assembly;
        var licenseKey = config.GetSection("MediatR:LicenseKey").Value;
        services.AddMediatR(config => 
        {
            config.LicenseKey = licenseKey;
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        var connectionString = config.GetConnectionString("PgConnection")!;
        services.AddMarten(options => 
        {
            options.Connection(connectionString);
            options.Schema.For<ShoppingCart>().Identity(c => c.AccountName);
        }).UseLightweightSessions();

        var redisConnectionString = config.GetConnectionString("RedisConnection");
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
            options.InstanceName = "Cart";
        });

        services.AddScoped<ICartRepository, CartRepository>();
        services.Decorate<ICartRepository, RedisCartCacheRepository>();

        var promotionServiceUri = config.GetSection("GrpcServices:PromotionService").Value!;
        services.AddGrpcClient<PromoService.PromoServiceClient>(options =>
        {
            options.Address = new Uri(promotionServiceUri);
        });

        services.AddBroker(config, null);

        TypeAdapterConfig.GlobalSettings.Scan(assembly); 
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddCommonLogging(config);

        return services;
    }

    public static WebApplication UseApiServices(
        this WebApplication app
        )
    {
        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseExceptionHandler(options => {});
        app.MapCarter();

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
