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

    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken token)
    {
        return await session.Query<CatalogItem>().ToListAsync(token);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken token)
    {
        if (brandTitle is null)
            throw new Exception("Название бренда не определено");

        return await session.Query<CatalogItem>().Where(
            item => item.Brand != null 
            && !string.IsNullOrEmpty(item.Brand.Title)
            && item.Brand.Title.ContainsIgnoreCase(brandTitle))
            .ToListAsync(token);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken token)
    {
        if (title is null)
            throw new Exception("Название элемента каталога не определено");

        return await session.Query<CatalogItem>().Where(
            item => item.Title != null 
            && !string.IsNullOrEmpty(title)
            && item.Title.ContainsIgnoreCase(title))
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
        //return session.Query<CatalogItem>().Where(item => item.IsDeleted()).Any();
    }
}
