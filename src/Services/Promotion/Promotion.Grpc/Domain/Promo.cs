namespace Promotion.Grpc.Domain;

/// <summary> Модель для промоакций </summary>
public class Promo
{
    /// <summary> Идентификатор </summary>
    public Guid Id { get; set; }

    /// <summary> Идентификатор элемента каталога </summary>
    public string? CatalogItemId { get; set; }

    /// <summary> Название промоакции </summary>
    public string Title { get; set; } = String.Empty;

    /// <summary> Значение </summary>
    public decimal Value { get; set; }
}
