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

        return services;
    }

    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();
        var connection = scope.ServiceProvider.GetRequiredService<IDbConnection>();
        await DatabaseExtentions.SeedAsync(connection);

        app.MapGrpcReflectionService();
        app.MapGrpcService<GreeterService>();
        return app;
    }
}