using FluentValidation;

namespace WebApi.Applications.ProductOperations.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x=>x.ProductId).GreaterThan(0);
        }
    }
}