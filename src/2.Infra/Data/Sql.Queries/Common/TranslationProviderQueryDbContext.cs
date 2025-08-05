using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace TranslationProvider.Infra.Data.Sql.Queries.Common;

public class TranslationProviderQueryDbContext : BaseQueryDbContext
{
    public TranslationProviderQueryDbContext(DbContextOptions<TranslationProviderQueryDbContext> options) : base(options)
    {
    }
}