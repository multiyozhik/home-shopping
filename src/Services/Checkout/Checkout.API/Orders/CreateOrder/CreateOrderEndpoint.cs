namespace Checkout.API.Orders.CreateOrder;


/// <summary> request для endpoint создания заказа </summary>
public record CreateOrderRequest(CreateOrderDto OrderData);


/// <summary> response для endpoint создания заказа </summary>
public record CreateOrderResponse(CreateOrderResultDto OrderResultDto);


/// <summary> endpoint для создания заказа </summary>
public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async ([FromBody] CreateOrderRequest request, ISender sender, CancellationToken token) =>
        {
            var command = new CreateOrderCommand(request.OrderData);
            var result = await sender.Send(command, token);
            var response = new CreateOrderResponse(result);
            return Results.Created($"/orders/{response.OrderResultDto.OrderId}", response);
        });
    }
}
