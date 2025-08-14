using Core.Contracts.Cultures.Commands;
using Core.Contracts.Cultures.Commands.Create;
using Core.Domain.Common.Consts;
using Core.Domain.Common.ValueObjects;
using Core.Domain.Cultures.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Core.ApplicationService.Cultures.Commands.Create;

public sealed class CultureCreateHandler(ZaminServices zaminServices, ICultureCommandRepository commandRepository)
    : CommandHandler<CultureCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(CultureCreateCommand command)
    {
        Culture entity = Culture.Create(command.ToParameter());

        if (await commandRepository.ExistsAsync(entity => entity.Key.Equals(command.Key)))
        {
            throw new InvalidEntityStateException(ProjectValidationErrors.VALIDATION_ERROR_DUPLICATE_VALUE,
                                                  command.Key,
                                                  CultureKey.CULTURE_KEY,
                                                  Culture.CULTURE);
        }

        await commandRepository.InsertAsync(entity);

        await commandRepository.CommitAsync();

        return await OkAsync(entity.BusinessId.Value);
    }
}