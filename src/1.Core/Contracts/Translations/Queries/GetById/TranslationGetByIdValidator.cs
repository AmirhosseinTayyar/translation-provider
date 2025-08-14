using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Translations.Queries.GetById;

public sealed class TranslationGetByIdValidator : AbstractValidator<TranslationGetByIdQuery>
{
    public TranslationGetByIdValidator(ITranslator translator)
    {
        RuleFor(query => query.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);
    }
}
