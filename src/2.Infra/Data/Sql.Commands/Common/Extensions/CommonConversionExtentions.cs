using Core.Domain.Common.ValueObjects;
using Infra.Data.Sql.Commands.Common.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Sql.Commands.Common.Extensions;

public static class CommonConversionExtentions
{
    public static void CommonConversions(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Title>()
            .HaveConversion<TitleConversion>();

        configurationBuilder
            .Properties<Name>()
            .HaveConversion<NameConversion>();

        configurationBuilder
            .Properties<Description>()
            .HaveConversion<DescriptionConversion>();

        configurationBuilder
            .Properties<LatinTitle>()
            .HaveConversion<LatinTitleConversion>();

        configurationBuilder
            .Properties<IsEnabled>()
            .HaveConversion<IsEnabledConversion>();

        configurationBuilder
            .Properties<CultureKey>()
            .HaveConversion<CultureKeyConversion>();
    }
}
