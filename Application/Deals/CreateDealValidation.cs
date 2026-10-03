using FluentValidation;

namespace Project.Application.Deals;

public  class CreateDealValidation : AbstractValidator<CreateDealCommand>
{
    public CreateDealValidation()
    {
        RuleFor(x => x.Title)
        .MaximumLength(100).NotEmpty();
        RuleFor(x => x.Amount)
        .GreaterThan(0)
        .LessThanOrEqualTo(100);
    }
}