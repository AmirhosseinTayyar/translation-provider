using Core.Contracts.Translations.Commands;
using Core.Domain.Translations.Entities;
using Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Infra.Data.Sql.Commands.Translations;

public sealed class TranslationCommandRepository(TranslationProviderCommandDbContext dbContext)
    : BaseCommandRepository<Translation, TranslationProviderCommandDbContext, int>(dbContext), ITranslationCommandRepository
{
}