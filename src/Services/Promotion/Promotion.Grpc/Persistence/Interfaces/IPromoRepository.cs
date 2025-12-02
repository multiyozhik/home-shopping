namespace Promotion.Grpc.Persistence.Interfaces;

/// <summary> Интерфейс репозитория промоакций </summary>
public interface IPromoRepository
{
    /// <summary> Метод возвращает промоакцию по id элемента каталога </summary>
    Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId, CancellationToken token);
}
