using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Translations.Queries.GetById;

public sealed class TranslationGetByIdValidator : AbstractValidator<TranslationGetByIdQuery>
{
    public TranslationGetByIdValidator(ITranslator translator)
    {
        RuleFor(query => query.BusinessId)
            .ProjectNotEmpty(translator, ProjectTranslation.BUSINESS_ID);
    }
}
