namespace Checkout.Application.Orders.Commands.ProcessOrderSubmission;

/// <summary> result команды обработки получения заказа </summary>
public record ProcessOrderSubmissionResult(Guid OrderId);

/// <summary> Команда обработки получения заказа </summary>
public record ProcessOrderSubmissionCommand(
    Guid OrderId,
    List<OrderItemDto> Items, 
    decimal TotalAmount,
    string AccountName,
    string FirstName,
    string Lastname,
    string Email,
    string Street,
    string City,
    string Region,
    string PostalCode,
    int PaymentMethod,
    string? CardNumber,
    string? ExpirationDate,
    string? OwnerLastName,
    string? OwnerFirstName,
    string? CvvCode,
    string CorrelationId
) : ICommand<ProcessOrderSubmissionResult>;


/// <summary> Обработчик команды получения заказа </summary>
/// <param name="orderRepository"> Репозиторий заказов </param>
public class ProcessOrderSubmissionCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<ProcessOrderSubmissionCommand, ProcessOrderSubmissionResult>
{
    // если уже есть в БД заказ с orderId, то повторно не добавляем, иначе добавляем новый заказ
    public async Task<ProcessOrderSubmissionResult> Handle(
        ProcessOrderSubmissionCommand command, CancellationToken token)
    {
        var orderId = command.OrderId;
        var order = await orderRepository.GetByIdAsync(orderId, token);
        if (order is null)
            return new ProcessOrderSubmissionResult(orderId);
        var addingOrder = command.Adapt<Order>();
        await orderRepository.AddAsync(addingOrder, token);
        return new ProcessOrderSubmissionResult(addingOrder.Id);
    }
}