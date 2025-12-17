namespace Checkout.Domain.Enums;

/// <summary> Способ оплаты </summary>
public enum PaymentMethod
{
    /// <summary> Оплата картой </summary>
    DebitCart = 0,

    /// <summary> Перевод со счета </summary>
    BankTransfer = 1
}
