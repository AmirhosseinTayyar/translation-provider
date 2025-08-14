using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Sql.Commands.Common.ValueConverters;

public class TitleConversion : ValueConverter<Title, string>
{
    public TitleConversion() : base(title => title.Value, value => Title.FromString(value))
    {
    }
}