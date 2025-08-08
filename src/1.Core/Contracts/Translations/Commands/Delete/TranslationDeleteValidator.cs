using FluentValidation;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Delete;

public sealed class TranslationDeleteValidator : AbstractValidator<TranslationDeleteCommand>
{
    public TranslationDeleteValidator()
    {

    }
}