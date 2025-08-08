using FluentValidation;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Create;

public sealed class TranslationCreateValidator : AbstractValidator<TranslationCreateCommand>
{
    public TranslationCreateValidator()
    {
    }
}