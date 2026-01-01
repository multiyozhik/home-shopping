namespace Common.Metrics.Extensions;

/// <summary> Класс для метода расширения для добавления middleware для снятия prometheus-метрик</summary>
public static class MetricExtensions
{
    public static WebApplication UsePrometheusMetrics(this WebApplication app)
    {
        app.UseHttpMetrics();  //для снятия метрик при выполнении pipeline обработки http-запроса
        app.UseMetricServer();  //чтобы появился новый endpoint /service/metrics
        return app;
    }
}
