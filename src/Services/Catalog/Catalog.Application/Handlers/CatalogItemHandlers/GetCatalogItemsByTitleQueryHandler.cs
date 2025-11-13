namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsByTitleQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsByTitleQuery, GetCatalogItemsByTitleResult>
{
    public async Task<GetCatalogItemsByTitleResult> Handle(
        GetCatalogItemsByTitleQuery query, CancellationToken token)
    {
        var catalogItemList = await catalogItemRepository.GetCatalogItemsByTitleAsync(query.Title, token);
        var result = new GetCatalogItemsByTitleResult(catalogItemList);
        return result;    
    }
}