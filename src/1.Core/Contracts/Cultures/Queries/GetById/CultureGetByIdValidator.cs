using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Cultures.Queries.GetById;

public sealed class CultureGetByIdValidator : AbstractValidator<CultureGetByIdQuery>
{
    public CultureGetByIdValidator(ITranslator translator)
    {
        RuleFor(query => query.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);
    }
}
