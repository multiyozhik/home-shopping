namespace Basket.API.Infrastructure;

/// <summary> Redis кеш-хранилище для корзины </summary>
public class RedisCartCacheRepository(
    ICartRepository cartRepository, IDistributedCache distributedCache)
    : ICartRepository
{
    /// <inheritdoc/>
    public async Task<ShoppingCart> GetShoppingCart(string accountName, CancellationToken token)
    {
        var cached = await distributedCache.GetStringAsync(accountName, token);
        if (!string.IsNullOrEmpty(cached)) 
            return JsonSerializer.Deserialize<ShoppingCart>(cached)!;

        var cart = await cartRepository.GetShoppingCart(accountName, token);
        await distributedCache.SetStringAsync(
            key: accountName,
            value: JsonSerializer.Serialize(cart),
            token: token);
        return cart;
    }

    /// <inheritdoc/>
    public async Task<bool> RemoveShoppingCart(string accountName, CancellationToken token)
    {
        var result = await cartRepository.RemoveShoppingCart(accountName, token);
        await distributedCache.RemoveAsync(accountName, token);
        return result;
    }
    
    /// <inheritdoc/>
    public async Task<ShoppingCart> SaveShoppingCart(ShoppingCart cart, CancellationToken token)
    {
        var result = await cartRepository.SaveShoppingCart(cart, token);
        await distributedCache.SetStringAsync(
            key: cart.AccountName, 
            value: JsonSerializer.Serialize(cart), 
            token: token);
        return result;
    }
}