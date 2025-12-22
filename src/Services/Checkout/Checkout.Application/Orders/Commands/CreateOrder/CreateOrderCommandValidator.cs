namespace Checkout.Application.Orders.Commands.CreateOrder;

/// <summary> Вылидатор для команды создания заказа </summary>
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OrderData).NotNull().WithMessage("Данные заказа не могут быть пустыми");

        RuleFor(x => x.OrderData.AccountName)
            .NotEmpty().WithMessage("Имя аккаунта обязательно должно быть заполнено")
            .NotNull().WithMessage("Имя аккаунта не может быть пустым")
            .MinimumLength(3).WithMessage("Имя аккаунта должно содержать не менее 3 символов")
            .MaximumLength(20).WithMessage("Имя аккаунта не должно превышать 20 символов")
            .Matches("^[a-zA-Z0-9_@.-]+$")
                .WithMessage("Имя аккаунта может содержать только буквы, цифры, подчеркивание, тире, точку или @");

        RuleFor(x => x.OrderData.Items).NotEmpty().WithMessage("Элементы заказа не могут быть пустыми");
        RuleForEach(x => x.OrderData.Items).ChildRules(i => 
        {
            i.RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity должен быть больше 0");;
            i.RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("UnitPrice должен быть больше 0");; 
            i.RuleFor(x => x.CatalogItemName).NotEmpty().WithMessage("CatalogItemName не может быть пустым");
        });

        RuleFor(x => x.OrderData)
            .Must(o => Math.Abs(o.TotalPrice - o.Items.Sum(i => i.Quantity * i.UnitPrice)) <= 0.01m)
            .WithMessage("Общая сумма не соответствует сумме исходя из количества товаров и цене за единицу");

        When(x => string.Compare(x.OrderData.PaymentMethod, PaymentMethod.DebitCart.ToString(), StringComparison.OrdinalIgnoreCase) == 0, () =>
        {
            RuleFor(x => x.OrderData.PaymentDetails).NotNull()
                .WithMessage("Реквизиты карты должны быть заполнены");
            RuleFor(x => x.OrderData.PaymentDetails!.CartNumber).CreditCard()
                .WithMessage("Неверный номер карты");
            RuleFor(x => x.OrderData.PaymentDetails!.CvvCode).Matches(@"^\d{3,4}$")
                .WithMessage("CVV должен быть 3 или 4 цифры");
            RuleFor(x => x.OrderData.PaymentDetails!.ExpirationDate).Matches(@"^(0[1-9]|1[0-2])\/\d{2}$")
                .WithMessage("Неверный срок действия карты");
        });

        When(x => string.Compare(x.OrderData.PaymentMethod, PaymentMethod.BankTransfer.ToString(), StringComparison.OrdinalIgnoreCase) == 0, () =>
        {
            RuleFor(x => x.OrderData.PaymentDetails).Null().WithMessage("Реквизиты карты должны быть null при BankTransfer"); 
        });

        RuleFor(x => x.OrderData.ContactInfo.FirstName)
            .NotEmpty().WithMessage("Имя пользователя обязательно должно быть заполнено")
            .NotNull().WithMessage("Имя пользователя не может быть пустым")
            .MinimumLength(2).WithMessage("Имя пользователя должно содержать не менее 2 символов")
            .MaximumLength(20).WithMessage("Имя пользователя не должно превышать 20 символов")
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
                .WithMessage("Имя пользователя может содержать только буквы");

        RuleFor(x => x.OrderData.ContactInfo.Lastname)
            .NotEmpty().WithMessage("Фамилия пользователя обязательно должна быть заполнена")
            .NotNull().WithMessage("Фамилия пользователя не может быть пустой")
            .MinimumLength(3).WithMessage("Фамилия пользователя должна содержать не менее 3 символов")
            .MaximumLength(20).WithMessage("Фамилия пользователя не должна превышать 20 символов")
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
                .WithMessage("Фамилия пользователя может содержать только буквы");

        RuleFor(x => x.OrderData.ContactInfo.Email).Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("Неверный email, должен содержать буквы, @, точку");

        RuleFor(x => x.OrderData.DeliveryAddress.PostalCode).Matches(@"^\d{6}$")
            .WithMessage("Почтовый индекс должен содержать 6 цифр");

        RuleFor(x => x.OrderData.DeliveryAddress.City)
            .NotEmpty().WithMessage("Город обязательно должен быть указан")
            .NotNull().WithMessage("Город не может быть пустым")
            .MinimumLength(2).WithMessage("Город должен содержать не менее 2 символов")
            .MaximumLength(25).WithMessage("Город не должен превышать 25 символов");

        RuleFor(x => x.OrderData.DeliveryAddress.Region)
            .NotEmpty().WithMessage("Регион обязательно должен быть указан")
            .NotNull().WithMessage("Регион не может быть пустым")
            .MinimumLength(3).WithMessage("Регион должен содержать не менее 3 символов")
            .MaximumLength(25).WithMessage("Регион не должен превышать 25 символов");

        RuleFor(x => x.OrderData.DeliveryAddress.Street)
            .NotEmpty().WithMessage("Улица обязательно должна быть указана")
            .NotNull().WithMessage("Улица не может быть пустой строкой")
            .MinimumLength(10).WithMessage("Улица должна содержать не менее 10 символов")
            .MaximumLength(100).WithMessage("Улица не должна превышать 100 символов");
    }
}
