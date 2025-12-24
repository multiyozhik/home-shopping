namespace Common.Messaging.Events.DTOs;

/// <summary> Dto для элемента заказа </summary>
public class OrderItemEventDto
{
    public string CatalogItemName { get; set; } = default!;
    public int Quantity { get; set; }    
    public decimal UnitPrice { get; set; }
}
