namespace Promotion.Grpc.UseCases.GetPromo;

/// <summary> Запрос промоакции по id элемента каталога </summary>
public record GetPromoByCatalogItemIdQuery(string? CatalogItemId)
    : IQuery<PromoModel>; 