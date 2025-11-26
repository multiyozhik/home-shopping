namespace Basket.API.ShoppingBasket.Remove;

public record RemoveCartCommand(string AccountName)
    : ICommand<RemoveCartResult>;