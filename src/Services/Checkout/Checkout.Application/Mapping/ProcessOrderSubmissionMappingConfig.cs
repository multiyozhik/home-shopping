namespace Checkout.Application.Mapping;

/// <summary> Mapster конфигурация для маппинга при обработке получения заказа </summary>
public class ProcessOrderSubmissionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProcessOrderSubmissionCommand, Order>()
            .Map(dest => dest.Id, src => src.OrderId)
            .Map(dest => dest.TotalAmount, src => src.TotalPrice)
            .Map(dest => dest.CurrentCartDetails, src => (src.CardNumber != null)
                ? new CartDetails(
                    src.CardNumber, 
                    src.ExpirationDate ?? "", 
                    src.OwnerLastName ?? "", 
                    src.OwnerFirstName ?? "", 
                    src.CvvCode ?? "")
                : null)
            .Map(dest => dest.ContactInfo, src => new Contact(src.FirstName, src.Lastname, src.Email))
            .Map(dest => dest.CurrentOrderStatus, src => OrderStatus.InProgress)
            .Map(dest => dest.CurrentPaymentMethod, src => (PaymentMethod)src.PaymentMethod)
            .Map(dest => dest.DeliveryAddress, src => new Address(src.Street, src.City, src.Region, src.PostalCode));
    }
}