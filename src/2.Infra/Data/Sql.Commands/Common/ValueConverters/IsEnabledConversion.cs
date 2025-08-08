using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Common.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.ValueConverters;

public class IsEnabledConversion : ValueConverter<IsEnabled, bool>
{
    public IsEnabledConversion() : base(isEnabled => isEnabled.Value, value => IsEnabled.FromBoolean(value))
    {
    }
}