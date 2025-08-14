using Core.Contracts.Cultures.Commands;
using Core.Contracts.Cultures.Commands.Update;
using Core.Domain.Common.Consts;
using Core.Domain.Common.Guards;
using Core.Domain.Cultures.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Core.ApplicationService.Cultures.Commands.Update;

public sealed class CultureUpdateHandler(ZaminServices zaminServices, ICultureCommandRepository commandRepository)
    : CommandHandler<CultureUpdateCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(CultureUpdateCommand command)
    {
        Culture entity = await commandRepository.GetAsync(command.BusinessId);

        EntityGuard.ThrowIfNull<Culture, int>(entity, Culture.CULTURE);

        if (await commandRepository.ExistsAsync(entity => !entity.BusinessId.Equals(command.BusinessId) && entity.Key.Equals(command.Key)))
        {
            throw new InvalidEntityStateException(ProjectValidationErrors.VALIDATION_ERROR_DUPLICATE_VALUE, Culture.CULTURE);
        }

        entity.Update(command.ToParameter());

        await commandRepository.CommitAsync();

        return Ok();
    }
}