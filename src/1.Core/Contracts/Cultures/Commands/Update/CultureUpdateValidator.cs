using Core.Contracts.Common.FluentValidation;
using Core.Domain.Common.Consts;
using Core.Domain.Common.ValueObjects;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Cultures.Commands.Update;

public sealed class CultureUpdateValidator : AbstractValidator<CultureUpdateCommand>
{
    public CultureUpdateValidator(ITranslator translator)
    {
        RuleFor(command => command.BusinessId)
            .ProjectNotEmpty(translator, ProjectNamings.BUSINESS_ID);

        RuleFor(command => command.Key)
            .ProjectNotEmpty(translator, CultureKey.CULTURE_KEY)
            .ProjectLength(translator, CultureKey.CULTURE_KEY, CultureKey.MIN_LENGTH, CultureKey.MAX_LENGTH);

        RuleFor(command => command.LatinTitle)
            .ProjectNotEmpty(translator, LatinTitle.LATIN_TITLE)
            .ProjectLength(translator, LatinTitle.LATIN_TITLE, LatinTitle.MIN_LENGTH, LatinTitle.MAX_LENGTH);
    }
}