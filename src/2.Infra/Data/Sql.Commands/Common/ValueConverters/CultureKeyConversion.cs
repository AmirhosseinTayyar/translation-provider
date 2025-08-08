using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Common.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.ValueConverters;

public class CultureKeyConversion : ValueConverter<CultureKey, string>
{
    public CultureKeyConversion() : base(cultureKey => cultureKey.Value, value => CultureKey.FromString(value))
    {
    }
}