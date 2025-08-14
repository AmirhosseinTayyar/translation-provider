using Core.Domain.Translations.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Translations.ValueConverters;

public class TranslationKeyConversion : ValueConverter<TranslationKey, string>
{
    public TranslationKeyConversion()
        : base(translationKey => translationKey.Value, value => TranslationKey.FromString(value))
    {
    }
}