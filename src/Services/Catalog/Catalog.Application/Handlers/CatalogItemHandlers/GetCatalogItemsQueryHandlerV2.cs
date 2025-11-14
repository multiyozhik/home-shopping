
using Catalog.Domain.Specifications;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandlerV2(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQueryV2, GetCatalogItemsResultV2>
{
    public async Task<GetCatalogItemsResultV2> Handle(GetCatalogItemsQueryV2 query, CancellationToken token)
    {
        var allCatalogItems = await catalogItemRepository.GetAllCatalogItemsAsync(token);
        var totalCount = allCatalogItems.Count();
        var items = allCatalogItems
            .Skip((query.PageIndex - 1) / query.PageSize)
            .Take(query.PageSize)
            .ToList();

        var pagination = new Pagination<CatalogItem>(
            query.PageIndex, query.PageSize, totalCount, items);
        return new GetCatalogItemsResultV2(pagination);
    }
}