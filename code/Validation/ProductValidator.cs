using Fluent_Validation.Data;
using FluentValidation;

namespace Fluent_Validation.Validation
{
    public class ProductValidator : AbstractValidator<SalesLT_Product>
    {
        public ProductValidator()
        {
            //not supported for client-side
            //RuleFor(x => x.Weight)
            //    .GreaterThan(0)
            //    .WithMessage("Weight must be positive");

            //supported by client-side
            RuleFor(x => x.Weight)
                .InclusiveBetween(0, decimal.MaxValue)
                .WithMessage("Weight must be positive");
        }
    }
}
