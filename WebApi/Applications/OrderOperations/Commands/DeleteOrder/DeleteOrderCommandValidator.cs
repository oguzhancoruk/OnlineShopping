using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x=>x.OrderId).GreaterThan(0);
        }
    }
}