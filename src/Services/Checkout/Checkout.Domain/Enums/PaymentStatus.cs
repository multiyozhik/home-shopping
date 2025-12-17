namespace Checkout.Domain.Enums;

/// <summary> Статус оплаты </summary>
public enum PaymentStatus
{
    /// <summary> В ожидании </summary>
    Pending = 0,

    /// <summary> Оплачено </summary>
    Completed = 1,

    /// <summary> Ошибка при оплате </summary>
    Failed = 2,

    /// <summary> Возврат средств </summary>
    Refunded = 3
}
