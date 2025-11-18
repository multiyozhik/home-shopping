namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsQueryV2(QueryArgs Args): IRequest<GetCatalogItemsResultV2>;