namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemByIdQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemByIdQuery, GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(
        GetCatalogItemByIdQuery query, CancellationToken token)
    {
        var catalogItem = await catalogItemRepository.GetCatalogItemAsync(query.Id, token);
        var result = new GetCatalogItemByIdResult(catalogItem);
        return result;
    }
}
