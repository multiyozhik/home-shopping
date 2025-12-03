
namespace Promotion.Grpc.UseCases.CreatePromo;

/// <summary> Обработчик команды создания промоакции </summary>
/// <param name="promoRepository"> Репозиторий промоакций </param>
public class CreatePromoCommandHandler(IPromoRepository promoRepository)
    : ICommandHandler<CreatePromoCommand, CreatePromoResponse>
{
    /// <summary> Метод создает промоакцию и возвращает модель ответа </summary>
    public async Task<CreatePromoResponse> Handle(
        CreatePromoCommand command, CancellationToken token)
    {
        command.Validate();

        var promo = new Promo
        {
            Id = Guid.NewGuid(),
            CatalogItemId = command.Promo.CatalogItemId,
            Title = command.Promo.Title,
            Value = (decimal)command.Promo.Value
        };

        var success = await promoRepository.CreateAsync(promo, token);
        
        return new CreatePromoResponse {
            Id = promo.Id.ToString(), 
            Success = success, 
            Description = success
                ? "Промоакция успешно создана"
                : "Ошибка при создании промоакции"
        };
    }
}
