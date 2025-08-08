using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Create;

public sealed class CultureCreateValidatior : AbstractValidator<CultureCreateCommand>
{
    public CultureCreateValidatior(ITranslator translator)
    {
        RuleFor(c => c.Key)
            .ProjectNotEmpty(translator, CultureKey.CULTURE_KEY)
            .ProjectLength(translator, CultureKey.CULTURE_KEY, CultureKey.MIN_LENGTH, CultureKey.MAX_LENGTH);

        RuleFor(c => c.LatinTitle)
            .ProjectNotEmpty(translator, LatinTitle.LATIN_TITLE)
            .ProjectLength(translator, LatinTitle.LATIN_TITLE, LatinTitle.MIN_LENGTH, LatinTitle.MAX_LENGTH);
    }
}