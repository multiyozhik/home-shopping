namespace Checkout.Application.Orders.Commands.DeleteOrder;

/// <summary> Валидатор для команды удаления заказа по OrderId </summary>
public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("Id заказа обязательно должен быть указан")
            .Must(id => Guid.TryParse(id, out Guid result))
            .WithMessage("Id заказа должен быть корректным Guid");
    }
}
