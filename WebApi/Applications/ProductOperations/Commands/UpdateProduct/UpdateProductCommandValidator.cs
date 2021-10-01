using FluentValidation;

namespace WebApi.Applications.ProductOperations.Commands.UpdateOrder
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
    
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x=>x.ProductId).GreaterThan(0);
        }

    }  
}