namespace Catalog.Application.Commands.CatalogItemCommands;

public record UpdateCatalogItemCommand(UpdateCatalogItemModel UpdateCatalogItemModel)
    : IRequest<UpdateCatalogItemResult>;