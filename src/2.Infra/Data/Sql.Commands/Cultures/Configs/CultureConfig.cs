using Core.Domain.Common.Consts;
using Core.Domain.Common.ValueObjects;
using Core.Domain.Cultures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zamin.Infra.Data.Sql.Commands.Extensions;

namespace Infra.Data.Sql.Commands.Cultures.Configs;

public sealed class CultureConfig : IEntityTypeConfiguration<Culture>
{
    public void Configure(EntityTypeBuilder<Culture> builder)
    {
        builder.AddRowVersionShadowProperty();

        builder.Property(c => c.BusinessId)
            .HasMaxLength(ProjectValues.BUSINESS_ID_LENGTH)
            .IsRequired();
        builder.HasIndex(c => c.BusinessId).IsUnique();

        builder.Property(c => c.Key)
            .HasMaxLength(CultureKey.MAX_LENGTH)
            .IsRequired();
        builder.HasIndex(c => c.Key).IsUnique();

        builder.Property(c => c.LatinTitle)
            .HasMaxLength(LatinTitle.MAX_LENGTH)
            .IsRequired();

        builder.Property(c => c.IsEnabled)
            .IsRequired();
    }
}