namespace Checkout.Application.Orders.Commands.UpdateOrder.DTOs;

/// <summary> Dto для реквизитов карты </summary>
/// <param name="CartNumber"> Номер карты </param>
/// <param name="ExpirationDate"> Срок истечения </param>
/// <param name="OwnerLastName"> Фамилия владельца карты </param>
/// <param name="OwnerFirstName"> Имя владельца карты </param>
/// <param name="CvvCode"> CVV / CVC код </param>
public record UpdateCartDetailsDto(
    string CartNumber, 
    string ExpirationDate, 
    string OwnerLastName, 
    string OwnerFirstName, 
    string CvvCode);