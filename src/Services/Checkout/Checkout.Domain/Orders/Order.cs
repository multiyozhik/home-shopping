namespace Checkout.Domain.Orders;

/// <summary> Заказ </summary>
public class Order : BaseEntity, IAggregateRoot
{
    /// <summary> Имя аккаунта заказчика </summary>
    public string AccountName { get; set; } = default!;

    /// <summary> Список элементов заказа </summary>
    public List<OrderItem> Items { get; set; } = [];
    
    /// <summary> Общая сумма заказа </summary>
    public decimal TotalAmount { get; set; }

    /// <summary> Статус заказа </summary>
    public OrderStatus CurrentOrderStatus { get; set; } = OrderStatus.Created;

    /// <summary> Контактная информация о заказчике </summary>
    public Contact ContactInfo { get; set; } = default!; 

    /// <summary> Адрес доставки заказа </summary>
    public Address DeliveryAddress { get; set; } = default!;

    /// <summary> Способ оплаты </summary>
    public PaymentMethod CurrentPaymentMethod { get; set; }

    /// <summary> Реквизиты карты </summary>
    public CartDetails? CurrentCartDetails { get; set; }

    /// <summary> Статус оплаты </summary>
    public PaymentStatus CurrentPaymentStatus { get; set; } = PaymentStatus.Pending;
}
