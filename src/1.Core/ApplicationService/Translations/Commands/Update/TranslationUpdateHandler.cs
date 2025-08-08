using TranslationProvider.Core.Contracts.Translations.Commands;
using TranslationProvider.Core.Contracts.Translations.Commands.Update;
using TranslationProvider.Core.Domain.Common.Guards;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Translations.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace TranslationProvider.Core.ApplicationService.Translations.Commands.Update;

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
            throw new InvalidEntityStateException(ProjectValidationError.VALIDATION_ERROR_DUPLICATE_VALUE, Translation.TRANSLATION);
        }

        entity.Update(command.ToParameter());

        await commandRepository.CommitAsync();

        return Ok();
    }
}