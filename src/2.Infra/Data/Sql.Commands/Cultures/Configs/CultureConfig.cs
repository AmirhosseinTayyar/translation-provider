using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Cultures.Entities;
using Zamin.Infra.Data.Sql.Commands.Extensions;

namespace TranslationProvider.Infra.Data.Sql.Commands.Cultures.Configs;

public sealed class CultureConfig : IEntityTypeConfiguration<Culture>
{
    public void Configure(EntityTypeBuilder<Culture> builder)
    {
        builder.AddRowVersionShadowProperty();

        builder.Property(c => c.BusinessId).HasMaxLength(ProjectConsts.BUSINESS_ID_LENGTH).IsRequired();
        builder.HasIndex(c => c.BusinessId).IsUnique();

        builder.Property(c => c.Key).HasMaxLength(Culture.KEY_MAX_LENGTH).IsRequired();
        builder.HasIndex(c => c.Key).IsUnique();

        builder.Property(c => c.LatinTitle).HasMaxLength(Culture.LATIN_TITLE_MAX_LENGTH).IsRequired();
    }
}