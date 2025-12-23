namespace Checkout.API.Orders.DeleteOrder;

/// <summary> request для удаления заказа по OrderId </summary>
public record DeleteOrderRequest(string OrderId);


/// <summary> response успешно ли удаление заказа </summary>
public record DeleteOrderResponse(bool IsDeleted);


/// <summary> endpoint для удаления заказа </summary>
public class DeleteOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders", async ([AsParameters] DeleteOrderRequest request, ISender sender, CancellationToken token) =>
        {
            var result = await sender.Send(new DeleteOrderCommand(request.OrderId), token);
            var response = new DeleteOrderResponse(result.IsDeleted);

            return result.IsDeleted 
                ? Results.Ok(response) 
                : Results.NotFound(response);
        });
    }
}
