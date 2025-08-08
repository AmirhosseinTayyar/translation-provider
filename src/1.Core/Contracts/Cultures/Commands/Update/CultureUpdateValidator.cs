using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Common.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Update;

public sealed class CultureUpdateValidator : AbstractValidator<CultureUpdateCommand>
{
    public CultureUpdateValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectTranslation.BUSINESS_ID);

        RuleFor(command => command.Key)
            .ProjectNotEmpty(translator, CultureKey.CULTURE_KEY)
            .ProjectLength(translator, CultureKey.CULTURE_KEY, CultureKey.MIN_LENGTH, CultureKey.MAX_LENGTH);

        RuleFor(command => command.LatinTitle)
            .ProjectNotEmpty(translator, LatinTitle.LATIN_TITLE)
            .ProjectLength(translator, LatinTitle.LATIN_TITLE, LatinTitle.MIN_LENGTH, LatinTitle.MAX_LENGTH);
    }
}