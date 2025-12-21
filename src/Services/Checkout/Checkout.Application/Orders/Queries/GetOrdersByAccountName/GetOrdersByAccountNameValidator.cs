namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName;

/// <summary> Валидатор для запроса получения всех заказов по accountName </summary>
public class GetOrdersByAccountNameValidator: AbstractValidator<GetOrdersByAccountNameQuery>
{
    public GetOrdersByAccountNameValidator()
    {
        RuleFor(x => x.AccountName)
            .NotEmpty().WithMessage("Имя аккаунта обязательно должно быть заполнено")
            .NotNull().WithMessage("Имя аккаунта не может быть пустым")
            .MinimumLength(3).WithMessage("Имя аккаунта должно содержать не менее 3 символов")
            .MaximumLength(20).WithMessage("Имя аккаунта не должно превышать 20 символов")
            .Matches("^[a-zA-Z0-9_@.-]+$")
                .WithMessage("Имя аккаунта может содержать только буквы, цифры, подчеркивание, тире, точку или @");
    }
}
