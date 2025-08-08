using System.ComponentModel;
using Zamin.Core.RequestResponse.Queries;

namespace TranslationProvider.Core.Contracts.Translations.Queries.GetFilterablePaged;

public sealed class TranslationGetFilterablePagedQuery : PageQuery<PagedData<TranslationListItemQr>>
{
    [Description("The key to filter translations.")]
    public string? Key { get; set; }

    [Description("The value to filter translations.")]
    public string? Value { get; set; }

    [Description("The culture to filter translations.")]
    public string? Culture { get; set; }
}