namespace Common.Messaging.Events;

/// <summary> Абстрактный класс интеграционного события </summary>
public abstract class BaseIntegrationEvent
{
    /// <summary> Идентификатор для отладки события </summary>
    public string CorrelationId { get; set; } = default!;

    /// <summary> Дата создания события </summary>
    public DateTime CreatingDate { get; private set; }

    /// <summary> Тип события </summary>
    public string EventType { get; set; } = default!;


    /// <summary> Конструктор </summary>
    protected BaseIntegrationEvent()
    {
        CorrelationId = Guid.NewGuid().ToString();
        CreatingDate = DateTime.UtcNow;
        EventType = GetType().Name;
    }


    /// <summary> Конструктор с параметрами </summary>
    protected BaseIntegrationEvent(Guid correlationId, DateTime creatingDate)
    {
        CorrelationId = correlationId.ToString();
        CreatingDate = creatingDate;
        EventType = GetType().Name;
    }
}