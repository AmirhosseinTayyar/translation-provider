using Core.Contracts.Translations.Commands;
using Core.Contracts.Translations.Commands.Create;
using Core.Domain.Common.Consts;
using Core.Domain.Translations.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Core.ApplicationService.Translations.Commands.Create;

public sealed class TranslationCreateHandler(ZaminServices zaminServices, ITranslationCommandRepository commandRepository)
    : CommandHandler<TranslationCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(TranslationCreateCommand command)
    {
        Translation entity = Translation.Create(command.ToParameter());

        if (await commandRepository.ExistsAsync(entity => entity.Key.Equals(command.Key) && entity.Culture.Equals(command.Culture)))
        {
            throw new InvalidEntityStateException(ProjectValidationErrors.VALIDATION_ERROR_DUPLICATE_VALUE, Translation.TRANSLATION);
        }

        await commandRepository.InsertAsync(entity);

        await commandRepository.CommitAsync();

        return await OkAsync(entity.BusinessId.Value);
    }
}