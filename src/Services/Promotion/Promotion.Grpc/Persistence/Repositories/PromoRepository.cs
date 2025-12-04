namespace Promotion.Grpc.Persistence.Repositories;

/// <summary> Репозиторий промоакций </summary>
public class PromoRepository(IDbConnection connection) : IPromoRepository
{
    /// <inheritdoc/>
    public async Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(catalogItemId);
        token.ThrowIfCancellationRequested();

        const string selectByCatalogItemId = """
            SELECT * FROM Promo
            WHERE CatalogItemId = @catalogItemId
            LIMIT 1;
        """;

        return await connection.QueryFirstOrDefaultAsync<Promo>(
            selectByCatalogItemId, new { CatalogItemId = catalogItemId });
    }
    
    /// <inheritdoc/>
    public async Task<bool> CreateAsync(Promo? promo, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(promo);
        token.ThrowIfCancellationRequested();

        const string insertPromo = """
            INSERT INTO Promo (Id, CatalogItemId, Title, Value) 
            VALUES (@id, @CatalogItemId, @Title, @Value); 
        """;

        var insertedRowsNumber = await connection.ExecuteAsync(
            insertPromo, promo);
        return insertedRowsNumber > 0;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Promo? promo, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(promo);
        token.ThrowIfCancellationRequested();

        const string updatePromo = """
            UPDATE Promo SET 
                Title = @Title,
                Value = @Value
            WHERE Id = @Id 
        """;
        var updatedRowsNumber = await connection.ExecuteAsync(updatePromo, promo);
        return updatedRowsNumber > 0;        
    }
    /// <inheritdoc/>
    public async Task<bool> DeleteByCatalogItemIdAsync(string? catalogItemId, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(catalogItemId);
        token.ThrowIfCancellationRequested();

        const string deletePromo = """
            DELETE FROM Promo
                WHERE CatalogItemId = @CatalogItemId
        """;

        var deletedRowsNumber = await connection.ExecuteAsync(
            deletePromo, new {CatalogItemId = catalogItemId});        
        return deletedRowsNumber > 0;
    }
}