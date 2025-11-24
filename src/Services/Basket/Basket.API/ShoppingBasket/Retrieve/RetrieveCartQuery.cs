namespace Basket.API.ShoppingBasket.Retrieve;

public record RetrieveCartQuery(string AccountName)
    : IQuery<RetrieveCartResult>;