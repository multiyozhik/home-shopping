namespace Promotion.Grpc.UseCases.UpdatePromo;

/// <summary> Команда для обновления промоакции по ее модели запроса </summary>
public record UpdatePromoCommand(UpdatePromoRequest Promo) : ICommand<UpdatePromoResponse>;