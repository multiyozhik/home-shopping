using System.Data;

namespace Checkout.Application.Orders.Commands.UpdateOrder;

/// <summary> Валидатор для команды обновления заказа </summary>
public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.OrderDataDto.OrderId)
            .NotNull().WithMessage("Id заказа обязательно должен быть указан")
            .NotEmpty().WithMessage("Id заказа не должен быть пустым")
            .Must(id => Guid.TryParse(id, out Guid orderId)).WithMessage("Id заказа должен быть корректным Guid");

        RuleFor(x => x.OrderDataDto.OrderData).NotNull()
            .WithMessage("Данные заказа не могут быть пустыми");

        When(x => x.OrderDataDto.OrderData.PaymentMethod != null 
            && string.Compare(
                x.OrderDataDto.OrderData.PaymentMethod, 
                PaymentMethod.DebitCart.ToString(), 
                StringComparison.OrdinalIgnoreCase) == 0, 
            () =>
            {
                RuleFor(x => x.OrderDataDto.OrderData.PaymentDetails)
                    .NotNull().WithMessage("Реквизиты карты должны быть заполнены");
                RuleFor(x => x.OrderDataDto.OrderData.PaymentDetails!.CartNumber)
                    .CreditCard().WithMessage("Неверный номер карты");
                RuleFor(x => x.OrderDataDto.OrderData.PaymentDetails!.CvvCode)
                    .Matches(@"^\d{3,4}$").WithMessage("CVV должен быть 3 или 4 цифры");
                RuleFor(x => x.OrderDataDto.OrderData.PaymentDetails!.ExpirationDate)
                    .Matches(@"^(0[1-9]|1[0-2])\/\d{2}$").WithMessage("Неверный срок действия карты");
            });

        When(x => x.OrderDataDto.OrderData.PaymentMethod != null 
            && string.Compare(
                x.OrderDataDto.OrderData.PaymentMethod, 
                PaymentMethod.BankTransfer.ToString(), 
                StringComparison.OrdinalIgnoreCase) == 0, 
            () =>
            {
                RuleFor(x => x.OrderDataDto.OrderData.PaymentDetails).Null()
                    .WithMessage("Реквизиты карты должны быть null при BankTransfer"); 
            });

        When (x => x.OrderDataDto.OrderData.ContactInfo != null, () =>
        {
            RuleFor(x => x.OrderDataDto.OrderData.ContactInfo!.FirstName)
                .NotEmpty().WithMessage("Имя пользователя обязательно должно быть заполнено")
                .NotNull().WithMessage("Имя пользователя не может быть пустым")
                .MinimumLength(2).WithMessage("Имя пользователя должно содержать не менее 2 символов")
                .MaximumLength(20).WithMessage("Имя пользователя не должно превышать 20 символов")
                .Matches("^[a-zA-Zа-яА-ЯёЁ]+$").WithMessage("Имя пользователя может содержать только буквы");            

            RuleFor(x => x.OrderDataDto.OrderData.ContactInfo!.Lastname)
                .NotEmpty().WithMessage("Фамилия пользователя обязательно должна быть заполнена")
                .NotNull().WithMessage("Фамилия пользователя не может быть пустой")
                .MinimumLength(3).WithMessage("Фамилия пользователя должна содержать не менее 3 символов")
                .MaximumLength(20).WithMessage("Фамилия пользователя не должна превышать 20 символов")
                .Matches("^[a-zA-Zа-яА-ЯёЁ]+$").WithMessage("Фамилия пользователя может содержать только буквы");

            RuleFor(x => x.OrderDataDto.OrderData.ContactInfo!.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Неверный email, должен содержать буквы, @, точку");
        });
              
        When (x => x.OrderDataDto.OrderData.DeliveryAddress != null, () =>
        {
            RuleFor(x => x.OrderDataDto.OrderData.DeliveryAddress!.PostalCode).Matches(@"^\d{6}$")
                .WithMessage("Почтовый индекс должен содержать 6 цифр");
            
            RuleFor(x => x.OrderDataDto.OrderData.DeliveryAddress!.City)
                .NotEmpty().WithMessage("Город обязательно должен быть указан")
                .NotNull().WithMessage("Город не может быть пустым")
                .MinimumLength(2).WithMessage("Город должен содержать не менее 2 символов")
                .MaximumLength(25).WithMessage("Город не должен превышать 25 символов");

            RuleFor(x => x.OrderDataDto.OrderData.DeliveryAddress!.Region)
                .NotEmpty().WithMessage("Регион обязательно должен быть указан")
                .NotNull().WithMessage("Регион не может быть пустым")
                .MinimumLength(3).WithMessage("Регион должен содержать не менее 3 символов")
                .MaximumLength(25).WithMessage("Регион не должен превышать 25 символов");

            RuleFor(x => x.OrderDataDto.OrderData.DeliveryAddress!.Street)
                .NotEmpty().WithMessage("Улица обязательно должна быть указана")
                .NotNull().WithMessage("Улица не может быть пустой строкой")
                .MinimumLength(10).WithMessage("Улица должна содержать не менее 10 символов")
                .MaximumLength(100).WithMessage("Улица не должна превышать 100 символов");
        });        
    }
}