
namespace Basket.API.ShoppingBasket.Remove;

public class RemoveCartCommandHandler(ICartRepository cartRepository)
    : ICommandHandler<RemoveCartCommand, RemoveCartResult>
{
    public async Task<RemoveCartResult> Handle(RemoveCartCommand command, CancellationToken token)
    {
        var accountName = command.AccountName;
        var isDeleted = await cartRepository.RemoveShoppingCart(accountName, token);
        return new RemoveCartResult(isDeleted);
    }
}