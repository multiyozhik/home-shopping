namespace Promotion.Grpc;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddGrpc();
        services.AddGrpcReflection();        

        var mySqlConnection = config.GetConnectionString("MySqlConnection");
        services.AddScoped<IDbConnection>(_ => new MySqlConnection(mySqlConnection));

        var assembly = typeof(Program).Assembly;
        var licenseKey = config.GetSection("MediatR:LicenseKey").Value;
        services.AddMediatR(config => 
        {
            config.LicenseKey = licenseKey;
            config.RegisterServicesFromAssembly(assembly);
        });

        services.AddScoped<IPromoRepository, PromoRepository>();

        MappingConfig.Configure();

        return services;
    }

    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();
        var connection = scope.ServiceProvider.GetRequiredService<IDbConnection>();

        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        await DatabaseExtentions.SeedAsync(connection, logger);

        app.MapGrpcReflectionService();
        app.MapGrpcService<PromoGrpcService>();
        return app;
    }
}