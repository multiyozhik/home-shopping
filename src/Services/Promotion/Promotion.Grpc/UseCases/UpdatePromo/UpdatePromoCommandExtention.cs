namespace Promotion.Grpc.UseCases.UpdatePromo;

/// <summary> Класс с методами расширения для команды обновления промоакций </summary>
public static class UpdatePromoCommandExtention
{
    /// <summary> Метод для валидации команды </summary>
    public static void Validate(this UpdatePromoCommand command)
    {
        var promo = command.Promo;

        var match = Regex.Match(promo.Title, @"\d+");

        if (!match.Success || !double.TryParse(match.Value, out double valueFromTitle))
            throw new RpcException(new Status(StatusCode.InvalidArgument, 
                "Ошибка при указании значения скидки при описании промоакции"));

        if (valueFromTitle != promo.Value)
            throw new RpcException(new Status(StatusCode.InvalidArgument,   
                "Значение скидки и описание не соответствуют друг другу"));

        if (!(command.Promo.Value > 0))
            throw new RpcException(new Status(StatusCode.InvalidArgument, 
                "Значение скидки должно быть больше 0"));        
    }    
}
