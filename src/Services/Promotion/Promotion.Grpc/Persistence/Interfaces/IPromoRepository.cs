namespace Promotion.Grpc.Persistence.Interfaces;

/// <summary> Интерфейс репозитория промоакций </summary>
public interface IPromoRepository
{
    /// <summary> Метод возвращает промоакцию по id элемента каталога </summary>
    Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId, CancellationToken token);

    /// <summary> Метод создания промоакции </summary>
    Task<bool> CreateAsync(Promo? promo, CancellationToken token);

    /// <summary> Метод обновляет промоакцию </summary>
    Task<bool> UpdateAsync(Promo? promo, CancellationToken token);
}
