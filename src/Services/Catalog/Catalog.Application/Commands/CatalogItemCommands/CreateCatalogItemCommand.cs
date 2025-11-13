using Catalog.Application.Models.CatalogItemModels;

namespace Catalog.Application.Commands.CatalogItemCommands;

public record CreateCatalogItemCommand(CreateCatalogItemModel CreateCatalogItemModel)
    : IRequest<CreateCatalogItemResult>;