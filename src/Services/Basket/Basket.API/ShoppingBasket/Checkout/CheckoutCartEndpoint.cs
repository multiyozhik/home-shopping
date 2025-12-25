namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> endpoint для формирования заказа </summary>
public class CheckoutCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost($"/cart/checkout", async (
            [FromBody] CheckoutCartRequest request, ISender sender, CancellationToken token) =>
        {
            // задаем correlationId, который передается в команду
            var correlationId = Guid.NewGuid().ToString();
            
            var command = request.Adapt<CheckoutCartCommand>();
            command = command with {CorrelationId = correlationId};            
            var result = await sender.Send(command, token);
            var response = result.Adapt<CheckoutCartResponse>();
            response = response with { Message = "Заказ сформирован" };
            return Results.Ok(response);  
        });
    }
}