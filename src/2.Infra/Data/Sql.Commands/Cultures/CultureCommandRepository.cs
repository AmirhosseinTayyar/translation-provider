using Core.Domain.Cultures.Entities;
using Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Infra.Data.Sql.Commands.Cultures;

public sealed class CultureCommandRepository(TranslationProviderCommandDbContext dbContext)
    : BaseCommandRepository<Culture, TranslationProviderCommandDbContext, int>(dbContext), ICultureCommandRepository
{
}