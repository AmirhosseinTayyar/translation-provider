using Core.Domain.Translations.ValueObjects;
using Infra.Data.Sql.Commands.Translations.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Sql.Commands.Translations.Extensions;

public static class TranslationConversionExtentions
{
    public static void TranslationConversions(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<TranslationKey>()
            .HaveConversion<TranslationKeyConversion>();

        configurationBuilder
            .Properties<TranslationValue>()
            .HaveConversion<TranslationValueConversion>();
    }
}
