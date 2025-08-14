using Infra.Data.Sql.Queries.Cultures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Sql.Queries.Cultures.Configs;

public sealed class CultureConfig : IEntityTypeConfiguration<Culture>
{
    public void Configure(EntityTypeBuilder<Culture> builder)
    {
        builder.Property(c => c.BusinessId).IsRequired();
        builder.HasIndex(c => c.BusinessId).IsUnique();

        builder.Property(c => c.Key).IsRequired();
        builder.HasIndex(c => c.Key).IsUnique();

        builder.Property(c => c.LatinTitle).IsRequired();
    }
}