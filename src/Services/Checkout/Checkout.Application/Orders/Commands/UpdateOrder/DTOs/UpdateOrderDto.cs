namespace Checkout.Application.Orders.Commands.UpdateOrder.DTOs;

/// <summary> Dto модель для обновления заказа </summary>
/// <param name="OrderId"> Id заказа </param>
/// <param name="OrderData"> Dto модель данных для обновления заказа </param>
public record UpdateOrderDto(
    string OrderId,
    UpdateDataDto OrderData
);