
namespace Basket.API.ShoppingBasket.Remove;

public class RemoveCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cart/{accountName}", async ([AsParameters] RemoveCartRequest request, ISender sender) =>
        {
            var command = new RemoveCartCommand(request.AccountName);
            var result = await sender.Send(command);
            var response = result.Adapt<RemoveCartResponse>();
            return Results.Ok(response);
        })
        .WithName("RemoveCartEndpoint")
        .Produces<RemoveCartResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Удаляет корзину")
        .WithDescription("Удаляет корзину по acccountName");
    }
}
