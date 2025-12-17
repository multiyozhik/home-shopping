namespace Checkout.Domain.ValueObjects;

/// <summary> Контактная информация о заказчике </summary>
/// <param name="FirstName"> Имя </param>
/// <param name="Lastname"> Фамилия </param>
/// <param name="Email"> Email </param>
public record Contact (string FirstName, string Lastname, string Email);