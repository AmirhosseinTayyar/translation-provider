using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace TranslationProvider.Infra.Data.Sql.Queries.Common;

public sealed class TranslationProviderQueryDbContext(DbContextOptions<TranslationProviderQueryDbContext> options)
    : BaseQueryDbContext(options)
{
}