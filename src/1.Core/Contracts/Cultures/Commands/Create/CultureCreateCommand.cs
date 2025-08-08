using System.ComponentModel;
using TranslationProvider.Core.Domain.Cultures.Parameters;
using Zamin.Core.RequestResponse.Commands;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Create;

public sealed record CultureCreateCommand : ICommand<Guid>
{
    [Description("The unique key for the culture.")]
    public string Key { get; init; } = default!;

    [Description("The Latin title for the culture.")]
    public string LatinTitle { get; init; } = default!;

    public CultureCreateParameter ToParameter() => new(Key, LatinTitle);
}