using Microsoft.EntityFrameworkCore;
using TranslationProvider.Core.Domain.Translations.ValueObjects;
using TranslationProvider.Infra.Data.Sql.Commands.Translations.ValueConverters;

namespace TranslationProvider.Infra.Data.Sql.Commands.Translations.Extensions;

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
