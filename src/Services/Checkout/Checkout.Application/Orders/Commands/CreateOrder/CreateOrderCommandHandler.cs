namespace Checkout.Application.Orders.Commands.CreateOrder;

/// <summary> Команда создания заказа </summary>
public record CreateOrderCommand(CreateOrderDto OrderData) : ICommand<CreateOrderResultDto>;

/// <summary> Обработчик для команды создания заказа </summary>
/// <param name="orderRepository"> Репозиторий заказов </param>
public class CreateOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<CreateOrderCommand, CreateOrderResultDto>
{
    public async Task<CreateOrderResultDto> Handle(CreateOrderCommand command, CancellationToken token)
    {
        var order = command.OrderData.Adapt<Order>();
        order.CurrentPaymentStatus = PaymentStatus.Pending;
        order.CurrentOrderStatus = OrderStatus.Created;
        await orderRepository.AddAsync(order, token);
        return new CreateOrderResultDto(order.Id, "Заказ создан");
    }
}
