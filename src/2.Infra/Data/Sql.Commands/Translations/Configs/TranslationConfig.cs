using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Cultures.Entities;
using TranslationProvider.Core.Domain.Translations.Entities;
using Zamin.Infra.Data.Sql.Commands.Extensions;

namespace TranslationProvider.Infra.Data.Sql.Commands.Translations.Configs;

public sealed class TranslationConfig : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.AddRowVersionShadowProperty();

        builder.Property(c => c.BusinessId).HasDefaultValueSql("NEWSEQUENTIALID()")
            .HasMaxLength(ProjectConsts.BUSINESS_ID_LENGTH).IsRequired();
        builder.HasIndex(c => c.BusinessId).IsUnique();

        builder.Property(c => c.Key).HasMaxLength(Translation.KEY_MAX_LENGTH).IsRequired();

        builder.Property(c => c.Value).HasMaxLength(Translation.VALUE_MAX_LENGTH).IsRequired();

        builder.Property(c => c.Culture).HasMaxLength(Culture.KEY_MAX_LENGTH).IsRequired();
    }
}