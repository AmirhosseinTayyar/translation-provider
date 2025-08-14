using System.ComponentModel;

namespace Core.Contracts.Cultures.Queries.GetSelectList;

public sealed class CultureSelectItemQr
{
    [Description("The key representing the culture.")]
    public string Key { get; set; } = default!;

    [Description("The translated Latin title of the culture.")]
    public string LatinTitleTranslated { get; set; } = default!;

    [Description("Indicates whether the culture is enabled.")]
    public bool IsEnabled { get; set; }
}