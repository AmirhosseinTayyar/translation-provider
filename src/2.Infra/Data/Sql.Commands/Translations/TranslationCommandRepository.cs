using TranslationProvider.Core.Contracts.Translations.Commands;
using TranslationProvider.Core.Domain.Translations.Entities;
using TranslationProvider.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace TranslationProvider.Infra.Data.Sql.Commands.Translations;

public sealed class TranslationCommandRepository(TranslationProviderCommandDbContext dbContext)
    : BaseCommandRepository<Translation, TranslationProviderCommandDbContext, int>(dbContext), ITranslationCommandRepository
{
}