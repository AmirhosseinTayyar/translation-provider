using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Common.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.ValueConverters;

public class DescriptionConversion : ValueConverter<Description, string>
{
    public DescriptionConversion() : base(description => description.Value, value => Description.FromString(value))
    {
    }
}