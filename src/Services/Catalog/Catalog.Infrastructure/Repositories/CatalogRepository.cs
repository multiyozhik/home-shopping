namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository(IDocumentSession session) : IBrandRepository, ICategoryRepository, ICatalogItemRepository
{
    public async Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken token)
    {
        return await session.Query<Brand>().ToListAsync(token);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken token)
    {
        return await session.Query<Category>().ToListAsync(token);
    }

    public async Task<Pagination<CatalogItem>> GetCatalogItemsAsync(QueryArgs args, CancellationToken token)
    {
        var allCatalogItems = session.Query<CatalogItem>().AsQueryable();
        var brandId = args.BrandId; 
        if(brandId != null)
        {
            allCatalogItems = allCatalogItems.Where(
                item => item.Brand != null && item.Brand.Id == brandId);
        }

        var categoryId = args.CategoryId;
        if (categoryId != null)
        {
            allCatalogItems = allCatalogItems.Where(
                item => item.Category != null && item.Category.Id == categoryId);
        }

        var search = args.Search;
        if(!string.IsNullOrEmpty(search))
        {
            allCatalogItems = allCatalogItems.Where(
                item => item.Title != null && item.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        var sort = args.Sort;
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
        var allItems = await allCatalogItems
            .Skip((args.PageIndex - 1) * args.PageSize)
            .Take(args.PageSize)
            .ToListAsync(token);

        return new Pagination<CatalogItem>(
            args.PageIndex, args.PageSize, totalCount, allItems);
    }

    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken token)
    {
        return await session.Query<CatalogItem>().ToListAsync(token);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken token)
    {
        // TODO: if (brandTitle is null) throw new Exception("Название бренда не определено");

        return await session.Query<CatalogItem>().Where(
            item => item.Brand != null 
            && !string.IsNullOrEmpty(item.Brand.Title)
            && item.Brand.Title.Contains(brandTitle, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(token);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken token)
    {
        // TODO: if (title is null) throw new Exception("Название элемента каталога не определено");

        return await session.Query<CatalogItem>().Where(
            item => item.Title != null 
            && !string.IsNullOrEmpty(title)
            && item.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(token);
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken token)
    {
        return await session.LoadAsync<CatalogItem>(id, token);
    }

    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken token)
    {
        session.Store(item);
        await session.SaveChangesAsync(token);
        return item;
    }

    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken token)
    {
        session.Store(item);
        await session.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken token)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync(token);
        return true;
        // TODO: return session.Query<CatalogItem>().Where(item => item.IsDeleted()).Any();
    }
}
