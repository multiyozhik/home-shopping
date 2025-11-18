namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandlerV2(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQueryV2, GetCatalogItemsResultV2>
{
    public async Task<GetCatalogItemsResultV2> Handle(GetCatalogItemsQueryV2 query, CancellationToken token)
    {
        var pagination = await catalogItemRepository.GetCatalogItemsAsync(query.Args, token);
        return new GetCatalogItemsResultV2(pagination);
    }
}