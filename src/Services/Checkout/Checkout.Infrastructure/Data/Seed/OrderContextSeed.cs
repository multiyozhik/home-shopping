namespace Checkout.Infrastructure.Data.Seed;

/// <summary> Класс для заполнения контекста заказов начальными данными </summary>
public static class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext)
    {
        if (!await orderContext.Orders.AnyAsync())
        {
            var orders = InitialData.Orders;

            foreach (var order in orders)
            {
                order.SetCreatedAudit("System");
            }

            orderContext.Orders.AddRange(orders);
            await orderContext.SaveChangesAsync();
        }
    }
}
