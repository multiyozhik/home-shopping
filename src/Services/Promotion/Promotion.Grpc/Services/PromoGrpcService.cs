namespace Promotion.Grpc.Services;

/// <summary> Grpc-сервис для промоакций </summary>
public class PromoGrpcService : PromoService.PromoServiceBase
{
    public override Task<PromoModel> GetPromo(GetPromoRequest request, 
        ServerCallContext context)
    {
        return base.GetPromo(request, context);
    }
}