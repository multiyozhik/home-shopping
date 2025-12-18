namespace Checkout.Domain.Repositories;

/// <summary> Интерфейс репозитория для заказов </summary>
public interface IOrderRepository : IRepository<Order>
{
    /// <summary> Метод получения всех заказов по accountName </summary>
    public Task<IEnumerable<Order>> GetOrdersByAccountName(string accountName);
}
