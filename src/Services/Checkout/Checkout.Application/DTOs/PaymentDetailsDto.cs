namespace Checkout.Application.DTOs;

/// <summary> Реквизиты карты </summary>
/// <param name="CartNumber"> Номер карты </param>
/// <param name="Expiration"> Срок истечения </param>
/// <param name="CartName"> Фамилия и имя владельца карты </param>
public record PaymentDetailsDto(string MaskedCartNumber, string Expiration, string CartName);
