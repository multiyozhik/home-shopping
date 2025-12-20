namespace Checkout.Application.Mapping;

/// <summary> Mapster конфигурация для возврата Dto в endpoint </summary>
public class GetOrdersByAccountNameMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, OrderDto>()
            .Map(dest => dest.TotalPrice, src => src.TotalAmount)
            .Map(dest => dest.OrderStatus, src => src.CurrentOrderStatus.ToString())
            .Map(dest => dest.PaymentMethod, src => src.CurrentPaymentMethod.ToString())
            .Map(dest => dest.PaymentStatus, src => src.CurrentPaymentStatus.ToString())
            .Map(dest => dest.Items, 
                src => src.Items.Select(i => new OrderItemDto(i.CatalogItemName, i.Quantity, i.UnitPrice)))
            .Map(dest => dest.PaymentDetails, src => (src.CurrentCartDetails == null)? null 
                : new PaymentDetailsDto(
                    Mask(src.CurrentCartDetails.CartNumber), 
                    src.CurrentCartDetails.ExpirationDate, 
                    $"{src.CurrentCartDetails.OwnerLastName} {src.CurrentCartDetails.OwnerFirstName}"));

        config.NewConfig<Contact, ContactDto>();
        config.NewConfig<Address, AddressDto>();
    }

    private string Mask(string cartNumber)
    {
        if (string.IsNullOrEmpty(cartNumber) || cartNumber.Length < 4)
            return cartNumber;
        return "**** **** **** " + cartNumber.Substring(cartNumber.Length-4);
    }
}
