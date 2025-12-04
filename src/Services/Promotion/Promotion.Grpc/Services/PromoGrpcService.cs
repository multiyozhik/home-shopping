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

    /// <summary> Метод создает промоакцию по запросу и возвращает модель ответа </summary>
    public override async Task<CreatePromoResponse> CreatePromo(
        CreatePromoRequest request, ServerCallContext context)
    {
        var command = new CreatePromoCommand(request);
        return await mediator.Send(command);
    }

    /// <summary> Метод обновляет промоакцию по запросу и возвращает модель ответа </summary>
    public override async Task<UpdatePromoResponse> UpdatePromo(
        UpdatePromoRequest request, ServerCallContext context)
    {
        var command = new UpdatePromoCommand(request);
        return await mediator.Send(command);
    }

    /// <summary> Метод удаляет промоакцию и возвращает модель ответа </summary>
    public override Task<DeletePromoResponse> DeletePromo(
        DeletePromoRequest request, ServerCallContext context)
    {
        var command = new DeletePromoCommand(request.CatalogItemId);
        return mediator.Send(command);
    }
}