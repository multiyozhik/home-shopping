namespace Basket.API.ShoppingBasket.Retrieve;

public class RetrieveCartQueryHandler(ICartRepository cartRepository)
    : IQueryHandler<RetrieveCartQuery, RetrieveCartResult>
{
    public async Task<RetrieveCartResult> Handle(RetrieveCartQuery query, CancellationToken token)
    {
        var cart = await cartRepository.GetShoppingCart(query.AccountName, token);
        return new RetrieveCartResult(cart);
    }
}