namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync();
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title);
    Task<CatalogItem?> GetCatalogItemAsync(Guid id);
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item);
    Task<bool> DeleteCatalogItemAsync(Guid id);
}
