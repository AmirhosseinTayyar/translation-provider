using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Cultures.Queries.GetFilterablePaged;

public sealed class CultureGetFilterablePagedValidator : AbstractValidator<CultureGetFilterablePagedQuery>
{
    public CultureGetFilterablePagedValidator(ITranslator translator)
    {
        When(query => !string.IsNullOrWhiteSpace(query.Key), () =>
        {
            RuleFor(q => q.Key!)
                .ProjectLength(translator, CultureKey.CULTURE_KEY, CultureKey.MIN_LENGTH, CultureKey.MAX_LENGTH);
        });

        When(query => !string.IsNullOrWhiteSpace(query.LatinTitle), () =>
        {
            RuleFor(q => q.LatinTitle!)
                .ProjectLength(translator, LatinTitle.LATIN_TITLE, LatinTitle.MIN_LENGTH, LatinTitle.MAX_LENGTH);
        });
    }
}
