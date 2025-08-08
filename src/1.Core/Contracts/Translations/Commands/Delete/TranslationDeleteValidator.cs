using FluentValidation;
using TranslationProvider.Core.Contracts.Common.FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Delete;

public sealed class TranslationDeleteValidator : AbstractValidator<TranslationDeleteCommand>
{
    public TranslationDeleteValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectTranslation.BUSINESS_ID);
    }
}