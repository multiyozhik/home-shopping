namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandlerV2(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQueryV2, GetCatalogItemsResultV2>
{
    public async Task<GetCatalogItemsResultV2> Handle(GetCatalogItemsQueryV2 query, CancellationToken token)
    {
        var allCatalogItems = await catalogItemRepository.GetAllCatalogItemsAsync(token);

        var brandId = query.Args.BrandId;
        if(brandId is not null)
        {
            allCatalogItems = allCatalogItems.Where(item => item.Brand?.Id == brandId);
        }

        var categoryId = query.Args.CategoryId;
        if(categoryId is not null)
        {
            allCatalogItems = allCatalogItems.Where(item => item.Category?.Id == categoryId);
        }

        var search = query.Args.Search;
        if(!string.IsNullOrEmpty(search))
        {
            allCatalogItems = allCatalogItems.Where(
                item => item.Title != null 
                &&  item.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        var sort = query.Args.Sort;
        if(!string.IsNullOrEmpty(sort))
        {
            allCatalogItems = sort.ToLower() switch
            {
                "price_desc" => allCatalogItems.OrderByDescending(item => item.Price),
                "price_asc" => allCatalogItems.OrderBy(item => item.Price),
                "title_desc" => allCatalogItems.OrderByDescending(item => item.Title),
                "title_asc" => allCatalogItems.OrderBy(item => item.Title),
                _ => allCatalogItems
            };
        }

        var totalCount = allCatalogItems.Count();
        var items = allCatalogItems
            .Skip((query.Args.PageIndex - 1) / query.Args.PageSize)
            .Take(query.Args.PageSize)
            .ToList();

        var pagination = new Pagination<CatalogItem>(
            query.Args.PageIndex, query.Args.PageSize, totalCount, items);
        return new GetCatalogItemsResultV2(pagination);
    }
}