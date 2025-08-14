using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Sql.Commands.Common;

public sealed class TranslationProviderCommandDbContextFactory : IDesignTimeDbContextFactory<TranslationProviderCommandDbContext>
{
    public TranslationProviderCommandDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.Development.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TranslationProviderCommandDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"));

        return new TranslationProviderCommandDbContext(builder.Options);
    }
}