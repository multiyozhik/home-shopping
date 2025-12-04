namespace Promotion.Grpc.UseCases.GetPromo;

/// <summary> Обработчик запроса получения промоакции </summary>
/// <param name="promoRepository">Репозиторий промоакций</param>
public class GetPromoByCatalogItemIdHandler(IPromoRepository promoRepository)
    : IQueryHandler<GetPromoByCatalogItemIdQuery, PromoModel>
{
    /// <summary> Метод получения промоакции по запросу по id элемента каталога </summary>
    public async Task<PromoModel> Handle(GetPromoByCatalogItemIdQuery query, CancellationToken token)
    {
        var catalogItemId = query.CatalogItemId;
        var promo = await promoRepository.GetByCatalogItemIdAsync(catalogItemId, token) 
            ?? throw new RpcException(new Status(
                StatusCode.NotFound, $"Промоакций для {catalogItemId} не найдено"));

        return promo.Adapt<PromoModel>();
    }
}