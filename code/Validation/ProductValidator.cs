using Fluent_Validation.Data;
using FluentValidation;

namespace Fluent_Validation.Validation
{
    public class ProductValidator : AbstractValidator<SalesLT_Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Weight)
                .GreaterThan(0)
                .WithMessage("Weight must be positive");

            //RuleFor(x => x.Weight)
            //    .InclusiveBetween(0, decimal.MaxValue)
            //    .WithMessage("Weight must be positive");
        }
    }
}
