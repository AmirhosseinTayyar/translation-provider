using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Cultures.Queries.GetById;

public sealed class CultureGetByIdValidator : AbstractValidator<CultureGetByIdQuery>
{
    public CultureGetByIdValidator(ITranslator translator)
    {
        RuleFor(query => query.BusinessId)
            .ProjectNotEmpty(translator, ProjectTranslation.BUSINESS_ID);
    }
}
