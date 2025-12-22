namespace Checkout.Application.Orders.Commands.CreateOrder.DTOs;

/// <summary> Dto для результата создания заказа </summary>
/// <param name="OrderId"> Идентификатор заказа </param>
/// <param name="Message"> Сообщение о результате создания заказа </param>
public record CreateOrderResultDto(
    Guid OrderId,
    string Message
);