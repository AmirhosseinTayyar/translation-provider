using TranslationProvider.Core.Contracts.Cultures.Commands;
using TranslationProvider.Core.Contracts.Cultures.Commands.Update;
using TranslationProvider.Core.Domain.Common.Guards;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Cultures.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace TranslationProvider.Core.ApplicationService.Cultures.Commands.Update;

public sealed class CultureUpdateHandler(ZaminServices zaminServices, ICultureCommandRepository commandRepository)
    : CommandHandler<CultureUpdateCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(CultureUpdateCommand command)
    {
        Culture entity = await commandRepository.GetAsync(command.BusinessId);

        EntityGuard.ThrowIfNull<Culture, int>(entity, Culture.CULTURE);

        if (await commandRepository.ExistsAsync(entity => !entity.BusinessId.Equals(command.BusinessId) && entity.Key.Equals(command.Key)))
        {
            throw new InvalidEntityStateException(ProjectValidationError.VALIDATION_ERROR_DUPLICATE_VALUE, Culture.CULTURE);
        }

        entity.Update(command.ToParameter());

        await commandRepository.CommitAsync();

        return Ok();
    }
}