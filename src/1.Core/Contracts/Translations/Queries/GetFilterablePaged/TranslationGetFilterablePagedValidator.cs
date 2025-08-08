using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.ValueObjects;
using TranslationProvider.Core.Domain.Translations.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Translations.Queries.GetFilterablePaged;

public sealed class TranslationGetFilterablePagedValidator : AbstractValidator<TranslationGetFilterablePagedQuery>
{
    public TranslationGetFilterablePagedValidator(ITranslator translator)
    {
        When(query => !string.IsNullOrWhiteSpace(query.Key), () =>
        {
            RuleFor(q => q.Key!)
                .ProjectLength(translator, TranslationKey.TRANSLATION_KEY, TranslationKey.MIN_LENGTH, TranslationKey.MAX_LENGTH);
        });

        When(query => !string.IsNullOrWhiteSpace(query.Value), () =>
        {
            RuleFor(query => query.Value!)
                .ProjectLength(translator, TranslationValue.TRANSLATION_VALUE, TranslationValue.MIN_LENGTH, TranslationValue.MAX_LENGTH);
        });

        When(query => !string.IsNullOrWhiteSpace(query.Culture), () =>
        {
            RuleFor(q => q.Culture!)
                .ProjectLength(translator, CultureKey.CULTURE_KEY, CultureKey.MIN_LENGTH, CultureKey.MAX_LENGTH);
        });
    }
}
