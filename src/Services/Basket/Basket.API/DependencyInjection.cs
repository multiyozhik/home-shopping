using Common.Kernel.Behaviors;
using Common.Kernel.Exceptions.Handler;

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

        services.AddScoped<ICartRepository, CartRepository>();

        return services;
    }

    public static WebApplication UseApiServices(
        this WebApplication app
        )
    {
        app.UseExceptionHandler(options => {});
        app.MapCarter();

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
