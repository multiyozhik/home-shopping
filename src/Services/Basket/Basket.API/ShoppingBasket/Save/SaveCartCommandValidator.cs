namespace Basket.API.ShoppingBasket.Save;

/// <summary> Валидатор для команды сохранения корзины </summary>
public class SaveCartCommandValidator: AbstractValidator<SaveCartCommand>
{
    /// <summary> Конструктор валидатора </summary>
    public SaveCartCommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull().WithMessage("Корзина не может быть null");

        RuleFor(x => x.Cart.AccountName)
            .NotNull().WithMessage("AccountName не может быть null")
            .MaximumLength(100).WithMessage("AccountName слишком длинный");

        RuleFor(x => x.Cart.Items)
            .NotEmpty().WithMessage("Корзина не может быть пустой");

        RuleForEach(x => x.Cart.Items)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.ItemId)
                    .NotEqual(Guid.Empty).WithMessage("ItemId должен быть валидным Guid");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity должен быть больше 0");

                item.RuleFor(i => i.UnitPrice)
                    .GreaterThan(0).WithMessage("UnitPrice должен быть больше 0");

                item.RuleFor(i => i.ItemTitle)
                    .NotEmpty().WithMessage("ItemTitle не может быть пустым");
            });
    }
}