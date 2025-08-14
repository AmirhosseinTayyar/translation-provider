using Core.Domain.Common.Consts;
using Core.Domain.Common.ValueObjects;
using Core.Domain.Translations.Entities;
using Core.Domain.Translations.ValueObjects;
using Infra.Data.Sql.Commands.Translations.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zamin.Infra.Data.Sql.Commands.Extensions;

namespace Infra.Data.Sql.Commands.Translations.Configs;

public sealed class TranslationConfig : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.AddRowVersionShadowProperty();

        builder.Property(c => c.BusinessId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd()
            .HasValueGenerator<GuidValueGenerator>()
            .HasMaxLength(ProjectValues.BUSINESS_ID_LENGTH)
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