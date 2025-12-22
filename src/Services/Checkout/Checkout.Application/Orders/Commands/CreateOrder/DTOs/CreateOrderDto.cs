namespace Checkout.Application.Orders.Commands.CreateOrder.DTOs;

/// <summary> Dto для создания заказа </summary>
/// <param name="AccountName"> Имя аккаунта заказчика </param>
/// <param name="Items"> Список элементов заказа </param>
/// <param name="TotalPrice"> Общая сумма заказа </param>
/// <param name="ContactInfo"> Контактная информация о заказчике </param>
/// <param name="DeliveryAddress"> Адрес доставки заказа </param>
/// <param name="PaymentMethod"> Способ оплаты </param>
/// <param name="PaymentDetails"> Реквизиты карты </param>
public record CreateOrderDto(
    string AccountName, 
    List<OrderItemDto> Items, 
    decimal TotalPrice,
    ContactDto ContactInfo, 
    AddressDto DeliveryAddress, 
    string PaymentMethod, 
    CreateCardDetailsDto? PaymentDetails
);