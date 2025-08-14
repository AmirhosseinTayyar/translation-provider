using Core.Contracts.Cultures.Commands;
using Core.Contracts.Cultures.Commands.Delete;
using Core.Domain.Common.Guards;
using Core.Domain.Cultures.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Core.ApplicationService.Cultures.Commands.Enable;

public sealed class CultureEnableHandler(ZaminServices zaminServices, ICultureCommandRepository commandRepository)
    : CommandHandler<CultureDeleteCommand>(zaminServices)
{
    public override async Task<CommandResult> Handle(CultureDeleteCommand command)
    {
        Culture entity = await commandRepository.GetAsync(command.BusinessId);

        EntityGuard.ThrowIfNull<Culture, int>(entity, Culture.CULTURE);

        entity.Enable();

        await commandRepository.CommitAsync();

        return Ok();
    }
}