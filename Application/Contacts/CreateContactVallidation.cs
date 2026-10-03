using FluentValidation;

namespace Project.Application.Contacts;

public class CreateContactVallidation : AbstractValidator<CreateContactCommand>
{
    public CreateContactVallidation()
    {
        RuleFor(c => c.Name)
        .NotEmpty()
        .MaximumLength(100);
        RuleFor(c => c.Email)
        .NotEmpty()
        .EmailAddress();
    }
}