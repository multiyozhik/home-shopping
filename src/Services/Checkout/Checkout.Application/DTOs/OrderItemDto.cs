namespace Checkout.Application.DTOs;

/// <summary> Элемент заказа </summary>
/// <param name="CatalogItemName"> Наименование </param>
/// <param name="Quantity"> Количество </param>
/// <param name="UnitPrice"> Цена за единицу </param>
public record OrderItemDto(string CatalogItemName, int Quantity, decimal UnitPrice);