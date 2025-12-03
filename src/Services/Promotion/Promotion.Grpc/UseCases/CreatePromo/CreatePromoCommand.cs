namespace Promotion.Grpc.UseCases.CreatePromo;

/// <summary> Команда для создания промоакции по ее модели запроса </summary>
public record CreatePromoCommand(CreatePromoRequest Promo)
    : ICommand<CreatePromoResponse>;