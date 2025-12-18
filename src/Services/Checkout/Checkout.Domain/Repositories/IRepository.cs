namespace Checkout.Domain.Repositories;

/// <summary> Интерфейс репозитория для операций записи и чтения сущности </summary>
public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T>
    where T : IAggregateRoot
{ }
