namespace Basket.API.Exceptions;

/// <summary> Исключение - корзина не найдена по accountName </summary>
public class CartNotFoundException : NotFoundException
{
    public CartNotFoundException(string accountName) 
        : base("ShoppingCart", accountName) { }
}
