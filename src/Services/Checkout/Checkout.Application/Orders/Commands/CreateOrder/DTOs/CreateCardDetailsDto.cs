namespace Checkout.Application.Orders.Commands.CreateOrder.DTOs;

/// <summary> Dto для реквизитов карты </summary>
/// <param name="CardNumber"> Номер карты </param>
/// <param name="ExpirationDate"> Срок истечения </param>
/// <param name="OwnerLastName"> Фамилия владельца карты </param>
/// <param name="OwnerFirstName"> Имя владельца карты </param>
/// <param name="CvvCode"> CVV / CVC код </param>
public record CreateCardDetailsDto(string CardNumber, string ExpirationDate, 
    string OwnerLastName, string OwnerFirstName, string CvvCode);
