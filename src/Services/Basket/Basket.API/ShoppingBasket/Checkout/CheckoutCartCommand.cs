namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> Команда для формирования заказа в брокер </summary>
public record CheckoutCartCommand(
    // данные для формирования заказа для брокера
    string AccountName,
    string FirstName,
    string Lastname,
    string Email,
    string Street,
    string City,
    string Region,
    string PostalCode,
    int PaymentMethod,
    string? CardNumber,
    string? ExpirationDate,
    string? OwnerLastName,
    string? OwnerFirstName,
    string? CvvCode,
    // Id интеграционного события формирования заказа
    string CorrelationId
) : ICommand<CheckoutCartResult>;
