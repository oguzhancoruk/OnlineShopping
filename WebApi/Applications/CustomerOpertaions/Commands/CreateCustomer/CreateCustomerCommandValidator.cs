using FluentValidation;

namespace WebApi.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.SurName).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.Phone).NotEmpty();
            RuleFor(x=>x.Model.Adress).NotEmpty().MinimumLength(3);
        }
    }
}