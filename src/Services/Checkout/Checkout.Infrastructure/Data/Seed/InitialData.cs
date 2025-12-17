namespace Checkout.Infrastructure.Data.Seed;

/// <summary> Класс с начальными данными для заказов </summary>
public static class InitialData
{
    public static IEnumerable<Order> Orders =>
    [
        new() {
            AccountName = "test_account",
            TotalAmount = 15670m,
            CurrentOrderStatus = OrderStatus.Paid,
            CurrentPaymentMethod = PaymentMethod.DebitCart,
            CurrentPaymentStatus = PaymentStatus.Completed,
            ContactInfo = new("Иван", "Иванов", "ivan@test.com"),
            DeliveryAddress = new("Ленина 1", "Москва", "Московская", "101000"),
            CurrentCartDetails = new("4111111111111111", "12/25", "Иванов", "Иван", "123"),
            Items =
            [
                new("Мультиварка Redmond RMC-M90", 1, 5890m),
                new("Бюджетный смартфон с хорошей камерой", 1, 7990m),
                new("Фен Polaris PHD 2077", 1, 1790m)
            ]
        },
        new() {
            AccountName = "admin@example.com",
            TotalAmount = 3290m,
            CurrentOrderStatus = OrderStatus.InProgress,
            CurrentPaymentMethod = PaymentMethod.BankTransfer,
            CurrentPaymentStatus = PaymentStatus.Pending,
            ContactInfo = new("Анна", "Петрова", "anna@example.com"),
            DeliveryAddress = new("Тверская 12", "Москва", "Московская", "101001"),
            CurrentCartDetails = null,
            Items = [ new("Кофеварка Polaris PCM 1516E", 1, 3290m) ]
        }
    ];
}
