namespace Checkout.Application.Orders.Commands.DeleteOrder;


/// <summary> Результат удаления с флагом успешности удаления </summary>
public record DeleteOrderResult(bool IsDeleted);


/// <summary> Команда удаления заказа по OrderId </summary>
public record DeleteOrderCommand(string OrderId): ICommand<DeleteOrderResult>;


/// <summary> Обработчик удаления заказа </summary>
public class DeleteOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken token)
    {
        var orderId = Guid.Parse(command.OrderId);
        var orderToDelete = await orderRepository.GetByIdAsync(orderId, token);
        if(orderToDelete is null)
            throw new NotFoundException(nameof(orderToDelete), orderId);
        var isDeleted = await orderRepository.DeleteAsync(orderToDelete, token);
        return new DeleteOrderResult(isDeleted);
    }
}
