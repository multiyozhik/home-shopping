namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery request, CancellationToken token)
    {
        var catalogItemList = await catalogItemRepository.GetAllCatalogItemsAsync(token);
        var result = new GetCatalogItemsResult(catalogItemList);
        return result;
    }
}
