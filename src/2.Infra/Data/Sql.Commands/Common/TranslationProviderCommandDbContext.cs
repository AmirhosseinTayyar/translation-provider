using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common;

public class TranslationProviderCommandDbContext : BaseOutboxCommandDbContext
{
    public TranslationProviderCommandDbContext(DbContextOptions<TranslationProviderCommandDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}