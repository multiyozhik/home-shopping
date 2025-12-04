namespace Promotion.Grpc.UseCases.UpdatePromo;

/// <summary> Обработчик команды обновления промоакции </summary>
/// <param name="promoRepository"> Репозиторий промоакций </param>
public class UpdatePromoCommandHandler(IPromoRepository promoRepository)
    : ICommandHandler<UpdatePromoCommand, UpdatePromoResponse>
{
    /// <summary> Метод обновляет промоакцию и возвращает модель ответа </summary>
    public async Task<UpdatePromoResponse> Handle(UpdatePromoCommand command, CancellationToken token)
    {
        command.Validate();

        var promo = command.Promo.Adapt<Promo>();

        var success = await promoRepository.UpdateAsync(promo, token);

        return new UpdatePromoResponse
        {
            Success = success,
            Description = success
                ? "Промоакция успешно обновлена"
                : "Ошибка при обновлении промоакции"
        };
    }
}
