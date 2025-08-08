using TranslationProvider.Core.Contracts.Cultures.Commands;
using TranslationProvider.Core.Contracts.Cultures.Commands.Create;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Cultures.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace TranslationProvider.Core.ApplicationService.Cultures.Commands.Create;

public sealed class CultureCreateHandler(ZaminServices zaminServices, ICultureCommandRepository commandRepository)
    : CommandHandler<CultureCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(CultureCreateCommand command)
    {
        Culture entity = Culture.Create(command.ToParameter());

        if (await commandRepository.ExistsAsync(entity => entity.Key.Equals(command.Key)))
        {
            throw new InvalidEntityStateException(ProjectValidationError.VALIDATION_ERROR_DUPLICATE_VALUE,
                                                  command.Key,
                                                  Culture.KEY,
                                                  Culture.CULTURE);
        }

        await commandRepository.InsertAsync(entity);

        await commandRepository.CommitAsync();

        return await OkAsync(entity.BusinessId.Value);
    }
}