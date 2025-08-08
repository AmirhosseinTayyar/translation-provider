using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Common.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.ValueConverters;

public class LatinTitleConversion : ValueConverter<LatinTitle, string>
{
    public LatinTitleConversion() : base(latinTitle => latinTitle.Value, value => LatinTitle.FromString(value))
    {
    }
}