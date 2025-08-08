using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.ValueObjects;
using TranslationProvider.Core.Domain.Translations.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Create;

public sealed class TranslationCreateValidator : AbstractValidator<TranslationCreateCommand>
{
    public TranslationCreateValidator(ITranslator translator)
    {
        RuleFor(command => command.Key)
            .ProjectNotEmpty(translator, TranslationKey.TRANSLATION_KEY)
            .ProjectLength(translator, TranslationKey.TRANSLATION_KEY, TranslationKey.MIN_LENGTH, TranslationKey.MAX_LENGTH);

        RuleFor(command => command.Value)
            .ProjectNotEmpty(translator, TranslationValue.TRANSLATION_VALUE)
            .ProjectLength(translator, TranslationValue.TRANSLATION_VALUE, TranslationValue.MIN_LENGTH, TranslationValue.MAX_LENGTH);

        RuleFor(command => command.Culture)
            .ProjectNotEmpty(translator, CultureKey.CULTURE_KEY)
            .ProjectLength(translator, CultureKey.CULTURE_KEY, CultureKey.MIN_LENGTH, CultureKey.MAX_LENGTH);
    }
}