namespace Checkout.Domain.Enums;

/// <summary> Статус заказа </summary>
public enum OrderStatus
{
    /// <summary> Создан новый заказ </summary>
    Created = 0,
    /// <summary> Заказ в обработке </summary>
    InProgress = 1,
    /// <summary> Заказ отгружен </summary>
    Shipped = 2,
    /// <summary> Заказ оплачен </summary>
    Paid = 3,
    /// <summary> Заказ отменен </summary>
    Canceled = 4
}
