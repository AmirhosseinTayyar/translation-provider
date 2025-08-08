using FluentValidation;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Update;

public sealed class TranslationUpdateValidator : AbstractValidator<TranslationUpdateCommand>
{
    public TranslationUpdateValidator()
    {

    }
}