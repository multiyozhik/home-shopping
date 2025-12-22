namespace Checkout.Application.Mapping;

/// <summary> Mapster конфигурация для маппинга CreateOrderDto в Order при создании заказа </summary>
public class CreateOrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderDto, Order>()
            .Map(dest => dest.Items, 
                src => src.Items.Select(i => new OrderItem(i.CatalogItemName, i.Quantity, i.UnitPrice)))
            .Map(dest => dest.TotalAmount, src => src.TotalPrice)
            .Map(dest => dest.CurrentPaymentMethod, src => Enum.Parse<PaymentMethod>(src.PaymentMethod))
            .Map(dest => dest.CurrentCartDetails, 
                src => (src.PaymentDetails == null) ? null : src.PaymentDetails.Adapt<CartDetails>());    

        config.NewConfig<ContactDto, Contact>();
        config.NewConfig<AddressDto, Address>();
    }
}