using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Common.ValueConverters;

public class LatinTitleConversion : ValueConverter<LatinTitle, string>
{
    public LatinTitleConversion() : base(latinTitle => latinTitle.Value, value => LatinTitle.FromString(value))
    {
    }
}