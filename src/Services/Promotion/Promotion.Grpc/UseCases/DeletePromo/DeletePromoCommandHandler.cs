namespace Promotion.Grpc.UseCases.DeletePromo;

/// <summary> Обработчик команды удаления промоакции </summary>
/// <param name="promoRepository"> Репозиторий промоакций </param>
public class DeletePromoCommandHandler(IPromoRepository promoRepository)
    : ICommandHandler<DeletePromoCommand, DeletePromoResponse>
{
    /// <summary> Метод удаляет промоакцию по id элемента каталога, возвращает модель ответа </summary>
    public async Task<DeletePromoResponse> Handle(DeletePromoCommand command, CancellationToken token)
    {
        var success = await promoRepository.DeleteByCatalogItemIdAsync(
            command.CatalogItemId, token);
        
        return new DeletePromoResponse
        {
            Success = success,
            Description = success
                ? "Промоакция успешно удалена."
                : "Ошибка при удалении промоакции."
        };
    }
}