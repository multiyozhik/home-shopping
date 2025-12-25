namespace Basket.API.ShoppingBasket.Checkout;

/// <summary> Валидатор для команды формирования заказа </summary>
public class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand>
{
    public CheckoutCartCommandValidator()
    {        
        RuleFor(x => x.AccountName)
            .NotEmpty().WithMessage("Имя аккаунта обязательно должно быть заполнено")
            .NotNull().WithMessage("Имя аккаунта не может быть пустым")
            .MinimumLength(3).WithMessage("Имя аккаунта должно содержать не менее 3 символов")
            .MaximumLength(20).WithMessage("Имя аккаунта не должно превышать 20 символов")
            .Matches("^[a-zA-Z0-9_@.-]+$")
                .WithMessage("Имя аккаунта может содержать только буквы, цифры, подчеркивание, тире, точку или @");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя пользователя обязательно должно быть заполнено")
            .NotNull().WithMessage("Имя пользователя не может быть пустым")
            .MinimumLength(2).WithMessage("Имя пользователя должно содержать не менее 2 символов")
            .MaximumLength(20).WithMessage("Имя пользователя не должно превышать 20 символов")
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
                .WithMessage("Имя пользователя может содержать только буквы");

        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("Фамилия пользователя обязательно должна быть заполнена")
            .NotNull().WithMessage("Фамилия пользователя не может быть пустой")
            .MinimumLength(3).WithMessage("Фамилия пользователя должна содержать не менее 3 символов")
            .MaximumLength(20).WithMessage("Фамилия пользователя не должна превышать 20 символов")
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
                .WithMessage("Фамилия пользователя может содержать только буквы");

        When(x => x.PaymentMethod == 0, () =>
        {
            RuleFor(x => x.CardNumber).CreditCard()
                .WithMessage("Неверный номер карты");
            RuleFor(x => x.CvvCode).Matches(@"^\d{3,4}$")
                .WithMessage("CVV должен быть 3 или 4 цифры");
            RuleFor(x => x.ExpirationDate).Matches(@"^(0[1-9]|1[0-2])\/\d{2}$")
                .WithMessage("Неверный срок действия карты");
        });

        When(x => x.PaymentMethod == 1, () =>
        {
            RuleFor(x => x.CardNumber).Null()
                .WithMessage("Номер карты не указывается для банковского перевода");
            RuleFor(x => x.CvvCode).Null()
                .WithMessage("Cvv код не указывается для банковского перевода");
            RuleFor(x => x.ExpirationDate).Null()
                .WithMessage("Срок действия карты не указывается для банковского перевода");
        });

        RuleFor(x => x.OwnerFirstName)
            .NotEmpty().WithMessage("Имя пользователя обязательно должно быть заполнено")
            .NotNull().WithMessage("Имя пользователя не может быть пустым")
            .MinimumLength(2).WithMessage("Имя пользователя должно содержать не менее 2 символов")
            .MaximumLength(20).WithMessage("Имя пользователя не должно превышать 20 символов")
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
                .WithMessage("Имя пользователя может содержать только буквы");

        RuleFor(x => x.OwnerLastName)
            .NotEmpty().WithMessage("Фамилия пользователя обязательно должна быть заполнена")
            .NotNull().WithMessage("Фамилия пользователя не может быть пустой")
            .MinimumLength(3).WithMessage("Фамилия пользователя должна содержать не менее 3 символов")
            .MaximumLength(20).WithMessage("Фамилия пользователя не должна превышать 20 символов")
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
                .WithMessage("Фамилия пользователя может содержать только буквы");

        RuleFor(x => x.Email).Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("Неверный email, должен содержать буквы, @, точку");

        RuleFor(x => x.PostalCode).Matches(@"^\d{6}$")
            .WithMessage("Почтовый индекс должен содержать 6 цифр");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Город обязательно должен быть указан")
            .NotNull().WithMessage("Город не может быть пустым")
            .MinimumLength(2).WithMessage("Город должен содержать не менее 2 символов")
            .MaximumLength(25).WithMessage("Город не должен превышать 25 символов");

        RuleFor(x => x.Region)
            .NotEmpty().WithMessage("Регион обязательно должен быть указан")
            .NotNull().WithMessage("Регион не может быть пустым")
            .MinimumLength(3).WithMessage("Регион должен содержать не менее 3 символов")
            .MaximumLength(25).WithMessage("Регион не должен превышать 25 символов");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Улица обязательно должна быть указана")
            .NotNull().WithMessage("Улица не может быть пустой строкой")
            .MinimumLength(10).WithMessage("Улица должна содержать не менее 10 символов")
            .MaximumLength(100).WithMessage("Улица не должна превышать 100 символов");
    }
}
