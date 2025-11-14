
namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class UpateCatalogItemHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<UpdateCatalogItemCommand, UpdateCatalogItemResult>
{
    public async Task<UpdateCatalogItemResult> Handle(UpdateCatalogItemCommand command, CancellationToken token)
    {
        // TODO: предусмотреть валидацию (проверка существования Brand, Category и т.п. 
        // в приходящей от пользователя модели данных)
        var catalogItem = command.UpdateCatalogItemModel.Adapt<CatalogItem>();
        var itemById = await catalogItemRepository.GetCatalogItemAsync(catalogItem.Id, token);
        if (itemById is null)
            return new UpdateCatalogItemResult(false);
        var isUpdated = await catalogItemRepository.UpdateCatalogItemAsync(catalogItem, token);
        return new UpdateCatalogItemResult(isUpdated);
    }
}
