namespace Basket.API.Models;

/// <summary> Элемент корзины </summary>
public class ShoppingCartItem
{
    /// <summary> Идентификатор </summary>
    public Guid ItemId { get; set; }

    /// <summary> Количество </summary>
    public int Quantity { get; set; }

    /// <summary> Стоимость за единицу </summary>
    public decimal UnitPrice { get; set; }

    /// <summary> Заголовок </summary>
    public string? ItemTitle { get; set; }

    /// <summary> Описание </summary>
    public string? ItemNote { get; set; }
}
