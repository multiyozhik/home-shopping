namespace Checkout.Domain.Repositories;

/// <summary> Интерфейс для операций чтения сущностей </summary>
public interface IReadRepository<T> where T : IAggregateRoot
{
    /// <summary> Метод получения списка всех сущностей </summary>
    public Task<IReadOnlyList<T>> GetAllAsync();

    /// <summary> Метод получения сущности по id </summary>
    public Task<T?> GetByIdAsync(Guid id);

    /// <summary> Метод получения списка сущностей, удовлетворяющих предикату в виде дерева выражений </summary>
    public Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
