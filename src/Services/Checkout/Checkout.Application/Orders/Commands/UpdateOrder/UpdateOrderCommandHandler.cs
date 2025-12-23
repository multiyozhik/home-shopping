namespace Checkout.Application.Orders.Commands.UpdateOrder;

/// <summary> Результат выполнения команды с флагом удалось ли обновить заказ </summary>
public record UpdateOrderResult(bool IsUpdated);


/// <summary> Команда обновления заказа по переданной модели данных </summary>
public record UpdateOrderCommand(UpdateOrderDto OrderDataDto) : ICommand<UpdateOrderResult>;


/// <summary> Обработчик команды обновления заказа </summary>
/// <param name="orderRepository"> Репозиторий заказов </param>
public class UpdateOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken token)
    {
        var orderId = Guid.Parse(command.OrderDataDto.OrderId);
        var orderToUpdate = await orderRepository.GetByIdAsync(orderId, token);
        if (orderToUpdate is null)
            throw new NotFoundException(nameof(orderToUpdate), orderId);
        command.OrderDataDto.OrderData.Adapt(orderToUpdate); 
        var isUpdated = await orderRepository.UpdateAsync(orderToUpdate, token);
        return new UpdateOrderResult(isUpdated);
    }
}