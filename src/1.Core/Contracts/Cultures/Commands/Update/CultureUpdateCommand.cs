using System.ComponentModel;
using TranslationProvider.Core.Domain.Cultures.Parameters;
using Zamin.Core.RequestResponse.Commands;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Update;

public sealed record CultureUpdateCommand : ICommand
{
    [Description("The BusinessId of the culture to update.")]
    public Guid BusinessId { get; init; }

    [Description("The unique key for the culture.")]
    public string Key { get; init; } = default!;

    [Description("The Latin title for the culture.")]
    public string LatinTitle { get; init; } = default!;

    public CultureUpdateParameter ToParameter() => new(Key, LatinTitle);
}