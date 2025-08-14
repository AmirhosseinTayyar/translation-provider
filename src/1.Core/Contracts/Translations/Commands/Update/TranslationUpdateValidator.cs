using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using Core.Domain.Common.ValueObjects;
using Core.Domain.Translations.ValueObjects;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Translations.Commands.Update;

public sealed class TranslationUpdateValidator : AbstractValidator<TranslationUpdateCommand>
{
    public TranslationUpdateValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);

        RuleFor(c => c.Key)
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