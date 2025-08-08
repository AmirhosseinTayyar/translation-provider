using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Cultures.Entities;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Update;

public sealed class CultureUpdateValidator : AbstractValidator<CultureUpdateCommand>
{
    public CultureUpdateValidator(ITranslator translator)
    {
        RuleFor(c => c.BusinessId)
            .PrjectNotEmpty(translator, ProjectTranslation.BUSINESS_ID);

        RuleFor(c => c.Key)
            .PrjectNotEmpty(translator, Culture.KEY)
            .PrjectLength(translator, Culture.KEY, Culture.KEY_MIN_LENGTH, Culture.KEY_MAX_LENGTH);

        RuleFor(c => c.LatinTitle)
            .PrjectNotEmpty(translator, Culture.LATIN_TITLE)
            .PrjectLength(translator, Culture.LATIN_TITLE, Culture.LATIN_TITLE_MIN_LENGTH, Culture.LATIN_TITLE_MAX_LENGTH);
    }
}