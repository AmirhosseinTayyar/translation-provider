using Infra.Data.Sql.Queries.Translations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Sql.Queries.Translations.Configs;

public sealed class TranslationConfig : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.Property(c => c.BusinessId).IsRequired();
        builder.HasIndex(c => c.BusinessId).IsUnique();

        builder.Property(c => c.Key).IsRequired();

        builder.Property(c => c.Value).IsRequired();

        builder.Property(c => c.Culture).IsRequired();
    }
}