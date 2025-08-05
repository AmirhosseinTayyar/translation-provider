using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common;

public class TranslationProviderCommandDbContextFactory : IDesignTimeDbContextFactory<TranslationProviderCommandDbContext>
{
    public TranslationProviderCommandDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TranslationProviderCommandDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"));

        return new TranslationProviderCommandDbContext(builder.Options);
    }
}