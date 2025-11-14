using Catalog.Domain.Specifications;

namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsResultV2(Pagination<CatalogItem> CatalogItems);