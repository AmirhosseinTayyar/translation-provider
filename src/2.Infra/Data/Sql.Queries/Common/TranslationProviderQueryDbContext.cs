using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace Infra.Data.Sql.Queries.Common;

public sealed class TranslationProviderQueryDbContext(DbContextOptions<TranslationProviderQueryDbContext> options)
    : BaseQueryDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("app");
        base.OnModelCreating(builder);
    }
}