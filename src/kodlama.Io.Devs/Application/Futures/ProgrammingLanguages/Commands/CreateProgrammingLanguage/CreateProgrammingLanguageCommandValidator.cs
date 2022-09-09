using FluentValidation;

namespace Application.Futures.ProgrammingLanguages.Commands.CreateProgrammingLanguages;

public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MinimumLength(1);
    }
}