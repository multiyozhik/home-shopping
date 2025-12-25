namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> request для endpoint формирования заказа </summary>
public record CheckoutCartRequest(
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
    string? CvvCode
);