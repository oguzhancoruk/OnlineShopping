using FluentValidation;

namespace WebApi.Applications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x=>x.CustomerId).GreaterThan(0);
        }
    }
}