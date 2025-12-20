namespace Checkout.Domain.Repositories;

/// <summary> Интерфейс для операций записи сущностей </summary>
public interface IWriteRepository<T> where T : IAggregateRoot
{
    /// <summary> Метод добавления сущности </summary>
    public Task AddAsync(T entity, CancellationToken token);

    /// <summary> Метод возвращает успешно ли выполнено обновление сущности </summary>
    public Task<bool> UpdateAsync(T entity, CancellationToken token);

    /// <summary> Метод возвращает успешно ли выполнено удаление сущности </summary>
    public Task<bool> DeleteAsync(T entity, CancellationToken token);
}
