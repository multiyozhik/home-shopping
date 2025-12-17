namespace Checkout.Domain.ValueObjects;

/// <summary> Контактная информация </summary>
/// <param name="Street"> Улица </param>
/// <param name="City"> Город </param>
/// <param name="Region"> Регион </param>
/// <param name="PostalCode"> Почтовый индекс </param>
public record Address(string Street, string City, string Region, string PostalCode);
