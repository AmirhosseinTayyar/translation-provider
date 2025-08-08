using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Common.ValueObjects;
using TranslationProvider.Core.Domain.Translations.Entities;
using TranslationProvider.Core.Domain.Translations.ValueObjects;
using Zamin.Infra.Data.Sql.Commands.Extensions;

namespace TranslationProvider.Infra.Data.Sql.Commands.Translations.Configs;

public sealed class TranslationConfig : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.AddRowVersionShadowProperty();

        builder.Property(c => c.BusinessId)
            .HasDefaultValue("NEWSEQUENTIALID()")
            .HasMaxLength(ProjectConsts.BUSINESS_ID_LENGTH)
            .IsRequired();
        builder.HasIndex(c => c.BusinessId).IsUnique();

        builder.Property(c => c.Key)
            .HasMaxLength(TranslationKey.MAX_LENGTH)
            .IsRequired();

        builder.Property(c => c.Value)
            .HasMaxLength(TranslationValue.MAX_LENGTH)
            .IsRequired();

        builder.Property(c => c.Culture)
            .HasMaxLength(CultureKey.MAX_LENGTH)
            .IsRequired();
    }
}