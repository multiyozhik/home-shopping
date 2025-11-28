namespace Basket.API.ShoppingBasket.Retrieve;

public class RetrieveCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cart/{accountName}", async ([AsParameters] RetrieveCartRequest request, ISender sender) =>
        {
            var query = new RetrieveCartQuery(request.AccountName);
            var result = await sender.Send(query);
            var response = result.Adapt<RetrieveCartResponse>();
            return Results.Ok(response);
        })
        .WithName("RetrieveCartEndpoint")
        .Produces<RetrieveCartResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Получает корзину пользователя")
        .WithDescription("Получает корзину по acccountName");
    }
}
