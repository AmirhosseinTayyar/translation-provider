using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Common.ValueConverters;

public class DescriptionConversion : ValueConverter<Description, string>
{
    public DescriptionConversion() : base(description => description.Value, value => Description.FromString(value))
    {
    }
}