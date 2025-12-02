namespace Promotion.Grpc.Persistence.Repositories;

/// <summary> Репозиторий промоакций </summary>
public class PromoRepository(IDbConnection connection) : IPromoRepository
{
    /// <inheritdoc/>
    public async Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(catalogItemId);

        const string selectByCatalogItemId = """
            SELECT * FROM Promo
            WHERE catalogItemId = @catalogItemId
            LIMIT 1;
        """;

        return await connection.QueryFirstOrDefaultAsync<Promo>(
            selectByCatalogItemId, new { CatalogItemId = catalogItemId });
    }
}