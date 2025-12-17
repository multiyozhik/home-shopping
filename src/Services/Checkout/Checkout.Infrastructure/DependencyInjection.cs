namespace Checkout.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var pgConnectionString = configuration.GetConnectionString("PgConnection");
        services.AddDbContext<OrderContext>(options => options.UseNpgsql(pgConnectionString));
        return services;
    }
}