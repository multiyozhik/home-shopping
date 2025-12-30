namespace Promotion.Grpc.Persistence.Extentions;

/// <summary> Класс для БД </summary>
public static class DatabaseExtentions
{
    /// <summary> Метод заполнения БД исходными данными с несколькими попытками подключения </summary>
    public static async Task SeedAsync<T>(IDbConnection connection, ILogger<T> logger, int maxRetries = 5)
    {
        var delay = TimeSpan.FromSeconds(1);

        Exception? lastException = default!;

        logger.LogInformation(
                "Начинается инициализация базы данных. Максимум попыток: {MaxRetries}", maxRetries);

        for (int i = 1; i <= maxRetries; i++)
        {
            try
            {
                if(connection.State != ConnectionState.Open)
                {
                    logger.LogInformation("Открытие соединения с базой данных");
                    connection.Open();
                }                    

                logger.LogDebug("Удаление таблицы Promo");
                const string dropTableSql = "DROP TABLE IF EXISTS Promo";
                await connection.ExecuteAsync(dropTableSql);

                logger.LogDebug("Создание таблицы Promo");
                const string createTableSql = @"CREATE TABLE IF NOT EXISTS Promo(
                    Id CHAR(36) NOT NUll PRIMARY KEY,
                    CatalogItemId VARCHAR(255) NOT NULL,
                    Title VARCHAR(255) NOT NUll,
                    Value DECIMAL(18,2) NOT NUll
                )";
                await connection.ExecuteAsync(createTableSql);

                var promos = InitData.GetInitialPromos;
                logger.LogInformation("Вставка {Count} записей в таблицу", promos.Count());

                const string insertSql = @"INSERT INTO Promo (Id, CatalogItemId, Title, Value)
                    VALUES (@Id, @CatalogItemId, @Title, @Value)";
                await connection.ExecuteAsync(insertSql, promos);

                logger.LogInformation("Инициализация базы данных успешно завершена");
                return;
            }
            catch (MySqlException ex) when (i < maxRetries)
            {
                lastException = ex;
                logger.LogWarning("Попытка {Attempt} из {MaxRetries} не удалась", i, maxRetries);

                if(connection.State == ConnectionState.Open)
                    connection.Close();
                await Task.Delay(delay);
                delay = TimeSpan.FromSeconds(Math.Min(delay.TotalSeconds * 2, 10));
            }
            catch (Exception ex)
            {
                lastException = ex;
                logger.LogCritical("Критическая ошибка на попытке {Attempt}", i);
                break;
            }
        }
        throw new InvalidOperationException(
            $"Не удалось подключиться к базе данных после {maxRetries} попыток",
            lastException);
    }
}