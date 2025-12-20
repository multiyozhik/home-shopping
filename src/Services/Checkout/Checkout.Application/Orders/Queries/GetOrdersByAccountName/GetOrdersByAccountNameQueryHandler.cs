namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName;

/// <summary> Запрос получения всех заказов по AccountName </summary>
public record GetOrdersByAccountNameQuery(string AccountName) 
    : IRequest<GetOrdersByAccountNameResult>;


/// <summary> Результат выполнения запроса всех заказов по AccountName </summary>
public record GetOrdersByAccountNameResult(IEnumerable<Order> Orders);


/// <summary> Обработчик запроса всех заказов по AccountName </summary>
public class GetOrdersByAccountNameQueryHandler(IOrderRepository orderRepository)

    : IRequestHandler<GetOrdersByAccountNameQuery, GetOrdersByAccountNameResult>
{
    public async Task<GetOrdersByAccountNameResult> Handle(
        GetOrdersByAccountNameQuery query, CancellationToken token)
    {
        var orders = await orderRepository.GetOrdersByAccountName(query.AccountName, token);
        return new GetOrdersByAccountNameResult(orders);
    }
}
