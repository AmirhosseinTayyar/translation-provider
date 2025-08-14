using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Common.ValueConverters;

public class IsEnabledConversion : ValueConverter<IsEnabled, bool>
{
    public IsEnabledConversion() : base(isEnabled => isEnabled.Value, value => IsEnabled.FromBoolean(value))
    {
    }
}