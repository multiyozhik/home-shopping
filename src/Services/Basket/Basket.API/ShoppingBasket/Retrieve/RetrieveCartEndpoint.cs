namespace Basket.API.ShoppingBasket.Retrieve;

public class RetrieveCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cart/{accountName}", async (string accountName, ISender sender) =>
        {
            var query = new RetrieveCartQuery(accountName);
            var result = await sender.Send(query);
            var response = result.Adapt<RetrieveCartResponse>();
            return Results.Ok(response);
        })
        .WithName("RetrieveCartEndpoint")
        .Produces<RetrieveCartResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Получает корзину пользователя")
        .WithDescription("Получает корзину по имени аккаунта, делающего заказ");
    }
}
