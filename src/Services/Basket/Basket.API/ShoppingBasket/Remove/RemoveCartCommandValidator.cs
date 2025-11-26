namespace Basket.API.ShoppingBasket.Remove;

/// <summary> Валидатор для команды удаления корзины </summary>
public class RemoveCartCommandValidator: AbstractValidator<RemoveCartCommand>
{
    public RemoveCartCommandValidator()
    {
        RuleFor(x => x.AccountName)
            .NotEmpty().WithMessage("AccountName не может быть пустым");
    }
}