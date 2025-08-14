using Core.Contracts.Translations.Commands;
using Core.Contracts.Translations.Commands.Delete;
using Core.Domain.Common.Guards;
using Core.Domain.Translations.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Core.ApplicationService.Translations.Commands.Delete;

public sealed class TranslationDeleteHandler(ZaminServices zaminServices, ITranslationCommandRepository commandRepository)
    : CommandHandler<TranslationDeleteCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(TranslationDeleteCommand command)
    {
        Translation entity = await commandRepository.GetAsync(command.BusinessId);

        EntityGuard.ThrowIfNull<Translation, int>(entity, Translation.TRANSLATION);

        entity.Delete();

        commandRepository.Delete(entity);

        await commandRepository.CommitAsync();

        return Ok();
    }
}