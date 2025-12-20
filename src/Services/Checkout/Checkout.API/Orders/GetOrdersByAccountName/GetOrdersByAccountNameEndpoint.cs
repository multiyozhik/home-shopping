namespace Checkout.API.Orders.GetOrdersByAccountName;

/// <summary> request для endpoint заказов по AccountName </summary>
public record GetOrdersByAccountNameRequest(string AccountName);


/// <summary> response для endpoint заказов по AccountName </summary>
public record GetOrdersByAccountNameResponse(IEnumerable<OrderDto> Orders);


/// <summary> endpoint получения всех заказов по AccountName </summary>
public class GetOrdersByAccountNameEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] GetOrdersByAccountNameRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetOrdersByAccountNameQuery>();
            var result = await sender.Send(query); 
            var response = result.Adapt<GetOrdersByAccountNameResponse>();
            return Results.Ok(response);
        });
    }
}