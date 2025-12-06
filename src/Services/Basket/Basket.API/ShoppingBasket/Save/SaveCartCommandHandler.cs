namespace Basket.API.ShoppingBasket.Save;

/// <summary> Обработчик команды сохранения корзины </summary>
/// <param name="cartRepository"> Репозиторий корзин </param>
/// <param name="promoService"> Сервис промоакций </param>
public class SaveCartCommandHandler(
        ICartRepository cartRepository, PromoService.PromoServiceClient promoService)
    : ICommandHandler<SaveCartCommand, SaveCartResult>
{
    /// <summary> Метод обработки команды </summary>
    public async Task<SaveCartResult> Handle(SaveCartCommand commmand, CancellationToken token)
    {
        var cart = commmand.Cart;
        await ApplyPromoToCartAsync(cart, token);
        await cartRepository.SaveShoppingCart(cart, token);
        return new SaveCartResult(cart.AccountName);
    }

    /// <summary> Метод применения промоакций к цене для каждого элемента корзины </summary>
    /// <param name="cart"> Корзина </param>
    private async Task ApplyPromoToCartAsync(ShoppingCart cart, CancellationToken token)
    {
        foreach(var item in cart.Items)
        {
            var itemPromo = await GetPromoForItemAsync(item, token);
            item.UnitPrice -= (decimal)itemPromo.Value;
        }
    }

    /// <summary> Метод получения промоакции для элемента корзины </summary>
    /// <param name="item"> Элемент корзины </param>
    private async Task<PromoModel> GetPromoForItemAsync(ShoppingCartItem item, CancellationToken token)
    {
        var request = new GetPromoRequest
        {
            CatalogItemId = item.ItemId.ToString()
        };
        return await promoService.GetPromoAsync(request, null, null, token);
    }
}
