
using Basket.API.Exceptions;

namespace Basket.API.Infrastructure;

/// <summary> Репозиторий корзины </summary>
public class CartRepository(IDocumentSession session) : ICartRepository
{
    /// <inheritdoc/>
    public async Task<ShoppingCart> GetShoppingCart(string accountName, CancellationToken token)
    {
        var cart = await session.LoadAsync<ShoppingCart>(accountName, token) 
            ?? throw new CartNotFoundException(accountName);

        return cart;
    }

    /// <inheritdoc/>
    public async Task<bool> RemoveShoppingCart(string accountName, CancellationToken token)
    {
        var cart = await session.LoadAsync<ShoppingCart>(accountName, token) 
            ?? throw new CartNotFoundException(accountName);

        session.Delete<ShoppingCart>(accountName);
        await session.SaveChangesAsync(token);
        return true;
    }

    /// <inheritdoc/>
    public async Task<ShoppingCart> SaveShoppingCart(ShoppingCart cart, CancellationToken token)
    {
        session.Store(cart);
        await session.SaveChangesAsync(token);
        return cart;
    }
}
