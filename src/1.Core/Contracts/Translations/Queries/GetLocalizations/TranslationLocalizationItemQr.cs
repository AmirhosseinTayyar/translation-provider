namespace TranslationProvider.Core.Contracts.Translations.Queries.GetLocalizations;
using System.ComponentModel;

public sealed class TranslationLocalizationItemQr
{
    [Description("The unique key for the translation localization.")]
    public string Key { get; set; } = string.Empty;

    [Description("The value for the translation localization.")]
    public string Value { get; set; } = string.Empty;

    [Description("The culture for the translation localization.")]
    public string Culture { get; set; } = string.Empty;
}