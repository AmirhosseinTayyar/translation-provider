namespace TranslationProvider.Core.Contracts.Translations.Queries.GetById;
using System.ComponentModel;

public sealed class TranslationQr
{
    [Description("The unique identifier of the translation record.")]
    public int Id { get; set; }

    [Description("The business identifier for the translation.")]
    public Guid BusinessId { get; set; }

    [Description("The unique key for the translation.")]
    public string Key { get; set; } = default!;

    [Description("The value for the translation.")]
    public string Value { get; set; } = default!;

    [Description("The culture for the translation.")]
    public string Culture { get; set; } = default!;
}
