namespace Basket.API.Infrastructure;

/// <summary> Интерфейс репозитория корзины </summary>
public interface ICartRepository
{
    /// <summary> Получить корзину </summary>
    public Task<ShoppingCart> GetShoppingCart(string accountName, CancellationToken token);

    /// <summary> Удалить корзину </summary>
    public Task<bool> RemoveShoppingCart(string accountName, CancellationToken token);

    /// <summary> Сохранить корзину </summary>
    public Task<ShoppingCart> SaveShoppingCart(ShoppingCart cart, CancellationToken token);
}
