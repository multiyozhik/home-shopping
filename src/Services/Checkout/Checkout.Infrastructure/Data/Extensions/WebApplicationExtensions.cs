namespace Checkout.Infrastructure.Data.Extensions;

/// <summary> Класс с методами расширения </summary>
public static class WebApplicationExtensions
{
    /// <summary> Метод расширения для IServiceProvider для выполнения миграций и заполнения БД начальными данными </summary>
    public static async Task MigrateAndSeedDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var orderContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
        await orderContext.Database.MigrateAsync();
        await OrderContextSeed.SeedAsync(orderContext);
    }
}
