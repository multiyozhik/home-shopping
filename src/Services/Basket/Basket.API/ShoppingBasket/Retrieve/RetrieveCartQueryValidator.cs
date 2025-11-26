namespace Basket.API.ShoppingBasket.Retrieve;

/// <summary> Валидатор для запроса получения корзины </summary>
public class RetrieveCartQueryValidator: AbstractValidator<RetrieveCartQuery>
{
    public RetrieveCartQueryValidator()
    {
        RuleFor(x => x.AccountName)
            .NotEmpty().WithMessage("AccountName не может быть пустым");
    }
}