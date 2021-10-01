using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x=>x.orderModel.Genre).NotEmpty();
            RuleFor(x=>x.orderModel.OrderId).GreaterThan(0);
           
        }
    }
}