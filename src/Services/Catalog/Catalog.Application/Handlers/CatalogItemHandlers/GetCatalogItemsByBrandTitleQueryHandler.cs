namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsByBrandTitleQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsByBrandTitleQuery, GetCatalogItemsByBrandTitleResult>
{
    public async Task<GetCatalogItemsByBrandTitleResult> Handle(
        GetCatalogItemsByBrandTitleQuery query, CancellationToken token)
    {
        var catalogItemList = await catalogItemRepository
            .GetCatalogItemsByBrandAsync(query.BrandTitle, token);
        var result = new GetCatalogItemsByBrandTitleResult(catalogItemList);
        return result;
    }
}
