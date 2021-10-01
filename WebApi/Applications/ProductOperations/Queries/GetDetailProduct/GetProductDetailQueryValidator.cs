using FluentValidation;
using WebApi.Applications.ProductOperations.Queries.GetProduct;

namespace WebApi.Applications.ProductOperations.Queries.GetDetailProduct
{
       public class GetProductDetailQueryValidator:AbstractValidator<GetProductDetailQuery>
    {

        public GetProductDetailQueryValidator()
        {
            RuleFor(x=>x.ProductId).GreaterThan(0);
        }
    }
}