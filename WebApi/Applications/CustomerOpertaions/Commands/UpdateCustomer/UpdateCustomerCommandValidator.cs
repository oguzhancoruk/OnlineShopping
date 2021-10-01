using FluentValidation;

namespace WebApi.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
    
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x=>x.CustomerId).GreaterThan(0);
        }

    }
    

    
}