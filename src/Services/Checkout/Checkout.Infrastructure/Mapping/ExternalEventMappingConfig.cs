namespace Checkout.Infrastructure.Mapping;

/// <summary> Mapster конфигурация для маппинга данных из события формирования заказа в команду </summary>
public class ExternalEventMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderSubmittedEvent, ProcessOrderSubmissionCommand>();
        config.NewConfig<OrderItemEventDto, OrderItemDto>();
    }
}