using FluentValidation;
using WS.CustomerBase.Application.Models.InputModels;

namespace WS.CustomerBase.Application.Validations;
public class ProductValidation : AbstractValidator<ProductInputModel>
{
    public ProductValidation()
    {
        RuleFor(x => x.Name).Length(3, 150).WithMessage("Please provide a valid name.");
        RuleFor(x => x.Price).NotEqual(decimal.Zero).WithMessage("The price cannot be zero.");
        RuleFor(x => x.Description).MaximumLength(250).WithMessage("Description cannot be greater than 250.");
    }
}