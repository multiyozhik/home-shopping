namespace Common.Messaging.Events;

/// <summary> Событие формирования заказа </summary>
public class OrderSubmittedEvent : BaseIntegrationEvent
{
    // Информация о заказе
    public string AccountName { get; set; } = default!;
    public List<OrderItemEventDto> Items { get; set; } = [];
    public decimal TotalPrice { get; set; }
    public string OrderStatus { get; set; } = default!;

    // Контактная информация
    public string FirstName { get; set; } = default!;
    public string Lastname { get; set; } = default!;    
    public string Email { get; set; } = default!;

    // Адрес доставки
    public string Street { get; set; } = default!;    
    public string City { get; set; } = default!;    
    public string Region { get; set; } = default!;    
    public string PostalCode { get; set; } = default!;

    // Информация об оплате
    public string PaymentMethod { get; set; } = default!;
    public string CardNumber { get; set; } = default!;   
    public string ExpirationDate { get; set; } = default!;
    public string OwnerLastName { get; set; } = default!;    
    public string OwnerFirstName { get; set; } = default!;    
    public string CvvCode { get; set; } = default!;
    public string PaymentStatus { get; set; } = default!;
}
