using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Translations.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Translations.ValueConverters;

public class TranslationKeyConversion : ValueConverter<TranslationKey, string>
{
    public TranslationKeyConversion()
        : base(translationKey => translationKey.Value, value => TranslationKey.FromString(value))
    {
    }
}