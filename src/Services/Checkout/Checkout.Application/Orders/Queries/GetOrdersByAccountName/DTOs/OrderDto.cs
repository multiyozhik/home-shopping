namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName.DTOs;

public record OrderDto(
    Guid Id,
    string AccountName, 
    List<OrderItemDto> Items, 
    decimal TotalPrice,
    string OrderStatus, 
    ContactDto ContactInfo, 
    AddressDto DeliveryAddress, 
    string PaymentMethod, 
    PaymentDetailsDto? PaymentDetails, 
    string PaymentStatus
);
