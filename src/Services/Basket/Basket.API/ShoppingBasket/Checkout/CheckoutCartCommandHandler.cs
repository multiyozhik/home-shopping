namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> Обработчик команды формирования заказа </summary>
/// <param name="publishEndpoint"> Интерфейс для публикации событий MassTransit </param>
/// <param name="sender"> Интерфейс в MediatR для отправки запросов или команд </param>
public class CheckoutCartCommandHandler(IPublishEndpoint publishEndpoint, ISender sender)
    : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
{
    // из команды по accountName получаем корзину, из нее Items и TotalPrice, 
    // формируем orderEvent - данные о заказе для брокера, публикуем и удаляем корзину
    public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken token)
    {        
        var accountName = command.AccountName;
        var retrieveCartQuery = new RetrieveCartQuery(accountName);
        var retrieveCartResult = await sender.Send(retrieveCartQuery, token);
        var cart = retrieveCartResult.Cart;
        if (cart is null)
            throw new NotFoundException(nameof(cart), accountName);  

        var orderEvent = command.Adapt<OrderSubmittedEvent>();        
        orderEvent.AccountName = command.AccountName;
        orderEvent.TotalPrice = cart.TotalPrice;
        orderEvent.Items = cart.Items.Select(i => i.Adapt<OrderItemEventDto>()).ToList();

        await publishEndpoint.Publish(orderEvent, token);

        var removeCartQuery = new RemoveCartCommand(accountName);
        var removeCartResult = await sender.Send(removeCartQuery, token);

        return new CheckoutCartResult(
            OrderId: Guid.NewGuid(),
            CorrelationId: command.CorrelationId,
            CartIsDeleted: removeCartResult.IsDeleted
        );
    }
}