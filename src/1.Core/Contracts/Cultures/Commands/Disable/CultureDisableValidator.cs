using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Disable;

public sealed class CultureDisableValidator : AbstractValidator<CultureDisableCommand>
{
    public CultureDisableValidator(ITranslator translator)
    {
        RuleFor(c => c.BusinessId)
            .PrjectNotEmpty(translator, ProjectTranslation.BUSINESS_ID);
    }
}