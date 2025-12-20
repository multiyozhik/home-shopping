namespace Checkout.Application.DTOs;

/// <summary> Контактная информация о заказчике </summary>
/// <param name="FirstName"> Имя </param>
/// <param name="Lastname"> Фамилия </param>
/// <param name="Email"> Email </param>
public record ContactDto (string FirstName, string Lastname, string Email);