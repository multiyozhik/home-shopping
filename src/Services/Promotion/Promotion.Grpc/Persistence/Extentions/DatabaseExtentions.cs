namespace Promotion.Grpc.Persistence.Extentions;

/// <summary> Класс для БД </summary>
public static class DatabaseExtentions
{
    /// <summary> Метод заполнения БД исходными данными </summary>
    /// <param name="connection"> Провайдер подключения к БД </param>
    public static async Task SeedAsync(IDbConnection connection)
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();

        const string dropTableSql = "DROP TABLE IF EXISTS Promo";
        await connection.ExecuteAsync(dropTableSql);

        const string createTableSql = @"CREATE TABLE IF NOT EXISTS Promo(
            Id CHAR(36) NOT NUll PRIMARY KEY,
            CatalogItemId VARCHAR(255) NOT NULL,
            Title VARCHAR(255) NOT NUll,
            Value DECIMAL(18,2) NOT NUll
        )";
        await connection.ExecuteAsync(createTableSql);

        var promos = InitData.GetInitialPromos;

        const string insertSql = @"INSERT INTO Promo (Id, CatalogItemId, Title, Value)
            VALUES (@Id, @CatalogItemId, @Title, @Value)";
        await connection.ExecuteAsync(insertSql, promos);
    }
}