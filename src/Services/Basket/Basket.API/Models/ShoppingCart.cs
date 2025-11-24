namespace Basket.API.Models;

/// <summary> Корзина </summary>
public class ShoppingCart
{
    /// <summary> Имя делающего заказ </summary>
    public string AccountName { get; set; } = default!;

    /// <summary> Набор элементов в корзине </summary>
    public List<ShoppingCartItem> Items { get; set; } = new();

    /// <summary> Общая стоимость корзины </summary>
    public decimal TotalPrice => Items.Sum(i => i.Quantity * i.UnitPrice);


    /// <summary> Конструктор корзины </summary>
    /// <param name="accountName">Имя делающего заказ</param>
    public ShoppingCart(string accountName)
    {
        AccountName = accountName;
    }

    /// <summary> Конструктор (по умолчанию) </summary>
    public ShoppingCart() { }
}
