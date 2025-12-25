namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> response для endpoint формирования заказа </summary>
public record CheckoutCartResponse(
    Guid OrderId,
    string CorrelationId,
    string Message
);