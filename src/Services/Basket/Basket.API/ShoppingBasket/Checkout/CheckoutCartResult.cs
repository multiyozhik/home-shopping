namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> result команды формирования заказа </summary>
/// <param name="OrderId"> Id заказа </param>
/// <param name="CorrelationId"> Id события </param>
/// <param name="CartIsDeleted"> Флаг удалена ли корзина </param>
public record CheckoutCartResult(
    Guid OrderId,
    string CorrelationId,
    bool CartIsDeleted
);