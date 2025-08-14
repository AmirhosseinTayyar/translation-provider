using Core.Domain.Cultures.Entities;
using Core.Domain.Translations.Entities;
using Infra.Data.Sql.Commands.Common.Extensions;
using Infra.Data.Sql.Commands.Translations.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Infra.Data.Sql.Commands.Common;

public sealed class TranslationProviderCommandDbContext(DbContextOptions<TranslationProviderCommandDbContext> options)
    : BaseOutboxCommandDbContext(options)
{
    public DbSet<Culture> Cultures { get; set; }
    public DbSet<Translation> Translations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("app");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.CommonConversions();
        configurationBuilder.TranslationConversions();
        base.ConfigureConventions(configurationBuilder);
    }
}