namespace Checkout.Domain.Common;

/// <summary> Абстрактный класс сущности </summary>
public abstract class BaseEntity
{
    /// <summary> Идентификатор </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary> Кто создал сущность </summary>
    public string? CreatedBy { get; set; }

    /// <summary> Дата и время создания сущности </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary> Кто последним изменил сущность </summary>
    public string? LastModifiedBy { get; set; }

    /// <summary> Дата и время последнего изменения </summary>
    public DateTime? LastModifiedAt { get; set; }

    /// <summary> Метод задания кто создал сущность </summary>
    public void SetCreatedAudit(string createdBy)
    {
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }
    /// <summary> Метод задания кто последний изменил сущность </summary>
    public void SetModifiedAudit(string lastModifiedBy)
    {
        LastModifiedBy = lastModifiedBy;
        LastModifiedAt = DateTime.UtcNow;
    }
}
