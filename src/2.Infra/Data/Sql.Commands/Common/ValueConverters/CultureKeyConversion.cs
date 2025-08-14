using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Common.ValueConverters;

public class CultureKeyConversion : ValueConverter<CultureKey, string>
{
    public CultureKeyConversion() : base(cultureKey => cultureKey.Value, value => CultureKey.FromString(value))
    {
    }
}