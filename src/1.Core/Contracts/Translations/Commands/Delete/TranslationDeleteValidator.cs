using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Translations.Commands.Delete;

public sealed class TranslationDeleteValidator : AbstractValidator<TranslationDeleteCommand>
{
    public TranslationDeleteValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);
    }
}