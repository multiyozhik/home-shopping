using Catalog.Application.Commands.CatalogItemCommands;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class CreateCatalogItemHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResult>
{
    public async Task<CreateCatalogItemResult> Handle(CreateCatalogItemCommand command, CancellationToken token)
    {
        // TODO: предусмотреть валидацию (проверка существования Brand, Category и т.п. 
        // в приходящей от пользователя модели данных)
        var catalogItem = command.CreateCatalogItemModel.Adapt<CatalogItem>();
        catalogItem.Id = Guid.NewGuid();
        await catalogItemRepository.CreateCatalogItemAsync(catalogItem, token);
        var result = new CreateCatalogItemResult(catalogItem.Id);
        return result;
    }
}
