namespace Basket.API.ShoppingBasket.Save;

public class SaveCartCommandHandler(ICartRepository cartRepository)
    : ICommandHandler<SaveCartCommand, SaveCartResult>
{
    public async Task<SaveCartResult> Handle(SaveCartCommand commmand, CancellationToken token)
    {
        var cart = commmand.Cart;
        cart = await cartRepository.SaveShoppingCart(cart, token);
        return new SaveCartResult(cart.AccountName);
    }
}
