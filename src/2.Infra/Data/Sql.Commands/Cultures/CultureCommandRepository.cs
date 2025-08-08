using TranslationProvider.Core.Contracts.Cultures.Commands;
using TranslationProvider.Core.Domain.Cultures.Entities;
using TranslationProvider.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace TranslationProvider.Infra.Data.Sql.Commands.Cultures;

public sealed class CultureCommandRepository(TranslationProviderCommandDbContext dbContext)
    : BaseCommandRepository<Culture, TranslationProviderCommandDbContext, int>(dbContext), ICultureCommandRepository
{
}