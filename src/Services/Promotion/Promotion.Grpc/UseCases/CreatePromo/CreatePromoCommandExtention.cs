namespace Promotion.Grpc.UseCases.CreatePromo;

/// <summary> Класс с методами расширения для команды создания промоакции </summary>
public static class CreatePromoCommandExtension
{
    /// <summary> Метод для валидации команды </summary>
    public static void Validate (this CreatePromoCommand command)
    {
        var promo = command.Promo;

        if(promo.CatalogItemId is null)
            throw new RpcException(new Status(
                    StatusCode.NotFound, $"Промоакций для {promo.CatalogItemId} не найдено"));

        if(!Guid.TryParse(promo.CatalogItemId, out Guid result) || result == Guid.Empty)
            throw new RpcException(new Status(StatusCode.InvalidArgument, 
                "CatalogItemId должен быть валидным Guid"));

        var match = Regex.Match(promo.Title, @"\d+");
        if (!match.Success || !double.TryParse(match.Value, out double valueFromTitle))
            throw new RpcException(new Status(StatusCode.InvalidArgument, 
                "Ошибка при указании значения скидки при описании промоакции"));

        if (valueFromTitle != promo.Value)
            throw new RpcException(new Status(StatusCode.InvalidArgument,   
                "Значение скидки и описание не соответствуют друг другу"));

        if (!(promo.Value > 0))
            throw new RpcException(new Status(StatusCode.InvalidArgument, 
                "Значение скидки должно быть больше 0"));
    }
}