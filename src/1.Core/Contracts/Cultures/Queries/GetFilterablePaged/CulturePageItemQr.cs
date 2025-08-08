using System.ComponentModel;

namespace TranslationProvider.Core.Contracts.Cultures.Queries.GetFilterablePaged;

public sealed class CulturePageItemQr
{
    [Description("The unique identifier of the culture.")]
    public int Id { get; set; }

    [Description("The business identifier (GUID) of the culture.")]
    public Guid BusinessId { get; set; }

    [Description("The key representing the culture.")]
    public string Key { get; set; } = default!;

    [Description("The Latin title of the culture.")]
    public string LatinTitle { get; set; } = default!;

    [Description("The translated Latin title of the culture.")]
    public string LatinTitleTranslated { get; set; } = default!;

    [Description("Indicates whether the culture is enabled.")]
    public bool IsEnabled { get; set; }
}