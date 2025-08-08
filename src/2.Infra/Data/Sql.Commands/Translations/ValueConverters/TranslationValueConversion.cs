using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Translations.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Translations.ValueConverters;

public class TranslationValueConversion : ValueConverter<TranslationValue, string>
{
    public TranslationValueConversion()
        : base(translationValue => translationValue.Value, value => TranslationValue.FromString(value))
    {
    }
}