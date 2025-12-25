namespace Common.Messaging.Extensions;

/// <summary> Класс для метода расширения для конфигурации MassTransit и RabbitMq /// </summary>
public static class MassTransitConfigurationExtension
{
    public static IServiceCollection AddBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly)
    {
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            if(assembly != null)
                config.AddConsumers(assembly);
            
            config.UsingRabbitMq((context, configigurator) =>
            {
                configigurator.Host(new Uri(configuration["Broker:Host"]!), host =>
                {
                    host.Username(configuration["Broker:UserName"]!);
                    host.Password(configuration["Broker:Password"]!);
                });
                configigurator.UseMessageRetry(retry =>
                {
                    retry.Interval(5, TimeSpan.FromSeconds(5));
                });
                configigurator.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}