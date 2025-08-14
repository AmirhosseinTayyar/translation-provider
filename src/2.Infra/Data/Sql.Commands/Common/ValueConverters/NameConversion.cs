using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Common.ValueConverters;

public class NameConversion : ValueConverter<Name, string>
{
    public NameConversion() : base(name => name.Value, value => Name.FromString(value))
    {
    }
}