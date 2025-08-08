using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common;

public sealed class TranslationProviderCommandDbContext(DbContextOptions<TranslationProviderCommandDbContext> options)
    : BaseOutboxCommandDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("app");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}