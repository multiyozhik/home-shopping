namespace Promotion.Grpc.Services;

/// <summary> Grpc-сервис для промоакций </summary>
public class PromoGrpcService (IMediator mediator) : PromoService.PromoServiceBase
{
    /// <summary> Метод возвращает модель промоакции по запросу </summary>
    public override async Task<PromoModel> GetPromo(GetPromoRequest request, 
        ServerCallContext context)
    {
        var query = new GetPromoByCatalogItemIdQuery(request.CatalogItemId);
        return await mediator.Send(query);
    }
}