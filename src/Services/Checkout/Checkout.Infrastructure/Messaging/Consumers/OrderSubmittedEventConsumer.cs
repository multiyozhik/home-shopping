namespace Checkout.Infrastructure.Messaging.Consumers;

/// <summary> Consumer для делегирования обработки события формирования заказа </summary>
public class OrderSubmittedEventConsumer(ISender sender) : IConsumer<OrderSubmittedEvent>
{
    public async Task Consume(ConsumeContext<OrderSubmittedEvent> context)
    {
        var command = context.Message.Adapt<ProcessOrderSubmissionCommand>();
        await sender.Send(command);
    }
}