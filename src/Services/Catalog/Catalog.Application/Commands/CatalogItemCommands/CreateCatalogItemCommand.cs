namespace Catalog.Application.Commands.CatalogItemCommands;

public record CreateCatalogItemCommand(CreateCatalogItemModel CreateCatalogItemModel)
    : IRequest<CreateCatalogItemResult>;