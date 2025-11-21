namespace Basket.API.ShoppingBasket.Save;

public class SaveCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/cart", async (SaveCartRequest request, ISender sender) =>
        {
            var command = request.Adapt<SaveCartCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<SaveCartResponse>();
            return Results.Created($"/cart/{response.AccountName}", response);
        });
    }
}