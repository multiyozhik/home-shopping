namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken token);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken token);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken token);
    Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken token);
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken token);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken token);
    Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken token);
}
