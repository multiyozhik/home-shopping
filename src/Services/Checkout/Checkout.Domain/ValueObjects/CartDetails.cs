namespace Checkout.Domain.ValueObjects;

/// <summary> Реквизиты карты </summary>
/// <param name="CartNumber"> Номер карты </param>
/// <param name="ExpirationDate"> Срок истечения </param>
/// <param name="OwnerLastName"> Фамилия владельца карты </param>
/// <param name="OwnerFirstName"> Имя владельца карты </param>
/// <param name="CvvCode"> CVV / CVC код </param>
public record CartDetails(string CartNumber, string ExpirationDate, 
    string OwnerLastName, string OwnerFirstName, string CvvCode);