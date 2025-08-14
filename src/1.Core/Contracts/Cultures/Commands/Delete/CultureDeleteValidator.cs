using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Cultures.Commands.Delete;

public sealed class CultureDeleteValidator : AbstractValidator<CultureDeleteCommand>
{
    public CultureDeleteValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);
    }
}