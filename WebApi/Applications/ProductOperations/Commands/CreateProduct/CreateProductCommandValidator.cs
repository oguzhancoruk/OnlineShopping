using FluentValidation;

namespace WebApi.Applications.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.productModel.Price).GreaterThan(0.0);
            RuleFor(x=>x.productModel.ProductId).GreaterThan(0);
        }
    }
}