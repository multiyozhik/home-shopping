namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> Mapster конфигурации при формировании заказа </summary>
public class CheckoutCartMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CheckoutCartRequest, CheckoutCartCommand>()
            .Map(dest => dest.CorrelationId, src => string.Empty);

        config.NewConfig<CheckoutCartResult, CheckoutCartResponse>()
            .Map(dest => dest.Message, src => "Заказ сформирован и отправлен на обработку");

        config.NewConfig<CheckoutCartCommand, OrderSubmittedEvent>()
            .Map(dest => dest.Items, src => new List<OrderItemEventDto>())
            .Map(dest => dest.TotalPrice, src => default(decimal));

        config.NewConfig<ShoppingCartItem, OrderItemEventDto>()
            .Map(dest => dest.CatalogItemName, src => "Unknown")
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.UnitPrice, src => src.UnitPrice);        
    }
}