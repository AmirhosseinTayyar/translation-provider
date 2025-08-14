using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Cultures.Commands.Enable;

public sealed class CultureEnableValidator : AbstractValidator<CultureEnableCommand>
{
    public CultureEnableValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);
    }
}