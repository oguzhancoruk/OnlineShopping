using FluentValidation;

namespace WebApi.Applications.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator:AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(x=>x.CustomerId).GreaterThan(0);
        }
    }
}