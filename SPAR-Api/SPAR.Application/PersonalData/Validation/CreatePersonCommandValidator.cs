using FluentValidation;
using SPAR.Application.PersonalData.Command;

namespace SPAR.Application.PersonalData.Validation;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Person).NotNull().WithMessage("Person is required");
        RuleFor(x => x.Person.Identifieringsinformation).NotNull().WithMessage("Identifieringsinformation is required");
        RuleFor(x => x.Person.Identifieringsinformation.UppdragId).NotNull().WithMessage("UppdragId is required");

        RuleFor(x => x.Person.PersonsokningFraga).NotNull().WithMessage("PersonsokningFraga is required");
        RuleFor(x => x.Person.PersonsokningFraga.Items)
            .NotNull()
            .When(x => x.Person.PersonsokningFraga is not null)
            .WithMessage("Items is required");
        RuleFor(x => x.Person.PersonsokningFraga.Items)
            .Must(x => x.Any())
            .When(x => x.Person.PersonsokningFraga?.Items is not null)
            .WithMessage("At least one item is required");
    }
}