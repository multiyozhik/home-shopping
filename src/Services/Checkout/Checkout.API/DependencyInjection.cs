namespace Checkout.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCarter();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var assembly = typeof(GetOrdersByAccountNameQuery).Assembly;
        var licenseKey = configuration.GetSection("MediatR:LicenseKey").Value;
        services.AddMediatR(config =>
        {
            config.LicenseKey = licenseKey;
            config.RegisterServicesFromAssembly(assembly);
        });

        return services;
    }
    
    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseSwagger();
        app.UseSwaggerUI();

        await app.Services.MigrateAndSeedDatabaseAsync();
    
        return app;
    }
}