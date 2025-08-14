using Core.Domain.Translations.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Translations.ValueConverters;

public class TranslationValueConversion : ValueConverter<TranslationValue, string>
{
    public TranslationValueConversion()
        : base(translationValue => translationValue.Value, value => TranslationValue.FromString(value))
    {
    }
}