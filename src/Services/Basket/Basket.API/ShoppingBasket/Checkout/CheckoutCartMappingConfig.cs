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
            .Map(dest => dest.Items, src => new List<OrderItemEventDto>());

        config.NewConfig<ShoppingCartItem, OrderItemEventDto>()
            .Map(dest => dest.CatalogItemName, src => src.ItemTitle)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.UnitPrice, src => src.UnitPrice);        
    }
}