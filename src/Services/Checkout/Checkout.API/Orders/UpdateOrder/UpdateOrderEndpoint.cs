namespace Checkout.API.Orders.UpdateOrder;

/// <summary> request для endpoint обновления заказа </summary>
public record UpdateOrderRequest(UpdateOrderDto OrderData);


/// <summary> response для endpoint обновления заказа </summary>
public record UpdateOrderResponse(bool IsUpdated);


/// <summary> endpoint для обновления заказа </summary>
public class UpdateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async([FromBody] UpdateOrderRequest request, ISender sender, CancellationToken token) =>
        {
            var command = new UpdateOrderCommand(request.OrderData);
            var result = await sender.Send(command,token);
            var response = new UpdateOrderResponse(result.IsUpdated);

            return result.IsUpdated
                ? Results.Ok(response)
                : Results.NotFound(response);
        });
    }
}