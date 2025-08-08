using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Common.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.ValueConverters;

public class NameConversion : ValueConverter<Name, string>
{
    public NameConversion() : base(name => name.Value, value => Name.FromString(value))
    {
    }
}