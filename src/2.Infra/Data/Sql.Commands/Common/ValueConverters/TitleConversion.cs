using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationProvider.Core.Domain.Common.ValueObjects;

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.ValueConverters;

public class TitleConversion : ValueConverter<Title, string>
{
    public TitleConversion() : base(title => title.Value, value => Title.FromString(value))
    {
    }
}