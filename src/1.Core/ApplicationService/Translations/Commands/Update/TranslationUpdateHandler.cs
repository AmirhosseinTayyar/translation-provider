using Core.Contracts.Translations.Commands;
using Core.Contracts.Translations.Commands.Update;
using Core.Domain.Common.Consts;
using Core.Domain.Common.Guards;
using Core.Domain.Translations.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Core.ApplicationService.Translations.Commands.Update;

public sealed class TranslationUpdateHandler(ZaminServices zaminServices, ITranslationCommandRepository commandRepository)
    : CommandHandler<TranslationUpdateCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(TranslationUpdateCommand command)
    {
        Translation entity = await commandRepository.GetAsync(command.BusinessId);

        EntityGuard.ThrowIfNull<Translation, int>(entity, Translation.TRANSLATION);

        if (await commandRepository.ExistsAsync(entity => !entity.BusinessId.Equals(command.BusinessId)
                                                           && entity.Key.Equals(command.Key)
                                                           && entity.Culture.Equals(command.Culture)))
        {
            throw new InvalidEntityStateException(ProjectValidationErrors.VALIDATION_ERROR_DUPLICATE_VALUE, Translation.TRANSLATION);
        }

        entity.Update(command.ToParameter());

        await commandRepository.CommitAsync();

        return Ok();
    }
}