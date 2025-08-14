using System.ComponentModel;
using Zamin.Core.RequestResponse.Queries;

namespace Core.Contracts.Cultures.Queries.GetFilterablePaged;

public sealed class CultureGetFilterablePagedQuery : PageQuery<PagedData<CulturePageItemQr>>
{
    [Description("Filter cultures by their unique key (e.g. \"fa-IR\", \"en-US\").")]
    public string? Key { get; init; }

    [Description("Filter cultures by their Latin title.")]
    public string? LatinTitle { get; init; }

    [Description("Filter cultures by their enabled status.")]
    public bool? IsEnabled { get; init; }
}