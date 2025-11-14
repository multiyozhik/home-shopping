
namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class DeleteCatalogItemByIdHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<DeleteCatalogItemByIdCommand, DeleteCatalogItemByIdResult>
{
    public async Task<DeleteCatalogItemByIdResult> Handle(DeleteCatalogItemByIdCommand command, CancellationToken token)
    {
        var catalogItem = await catalogItemRepository.GetCatalogItemAsync(command.Id, token);
        if (catalogItem is null)
            return new DeleteCatalogItemByIdResult(false);
        var isDeleted = await catalogItemRepository.DeleteCatalogItemAsync(command.Id, token);
        return new DeleteCatalogItemByIdResult(isDeleted);
    }
}