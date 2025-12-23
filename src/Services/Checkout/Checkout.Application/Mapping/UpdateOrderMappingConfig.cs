namespace Checkout.Application.Mapping;

/// <summary> Mapster конфигурация для маппинга UpdateOrderDto в Order при обновлении заказа </summary>
public class UpdateOrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<UpdateDataDto, Order>.NewConfig()
            .IgnoreNullValues(true)
            .AfterMapping((src, dest) =>
            {
                if (src.PaymentStatus != null)
                    dest.CurrentOrderStatus = Enum.Parse<OrderStatus>(src.PaymentStatus);
                if (src.PaymentMethod != null)
                    dest.CurrentPaymentMethod = Enum.Parse<PaymentMethod>(src.PaymentMethod);
                if (src.DeliveryAddress != null)
                    dest.DeliveryAddress = src.DeliveryAddress.Adapt<Address>();
                if (src.PaymentDetails != null)
                    dest.CurrentCartDetails = src.PaymentDetails.Adapt<CartDetails>();
                if (src.PaymentMethod != null)
                    dest.CurrentCartDetails = (src.PaymentMethod == PaymentMethod.BankTransfer.ToString())
                        ? dest.CurrentCartDetails = null
                        : src.PaymentDetails.Adapt<CartDetails>();
                if (src.ContactInfo != null)
                    dest.ContactInfo = src.ContactInfo.Adapt<Contact>();
            });
    }
}