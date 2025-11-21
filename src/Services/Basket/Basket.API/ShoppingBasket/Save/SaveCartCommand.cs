namespace Basket.API.ShoppingBasket.Save;

public record SaveCartCommand(ShoppingCart Cart)
    : ICommand<SaveCartResult>;