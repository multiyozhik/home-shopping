namespace Checkout.Application.Orders.Commands.UpdateOrder.DTOs;

/// <summary> Dto модель данных для обновления заказа </summary>
/// <param name="ContactInfo"> Контактная информация </param>
/// <param name="DeliveryAddress"> Адрес доставки </param>
/// <param name="PaymentMethod"> Способ оплаты </param>
/// <param name="PaymentDetails"> Реквизиты карты </param>
/// <param name="PaymentStatus"> Статус оплаты </param>
public record UpdateDataDto(
    ContactDto? ContactInfo, 
    AddressDto? DeliveryAddress, 
    string? PaymentMethod, 
    UpdateCartDetailsDto? PaymentDetails,
    string? PaymentStatus
);
