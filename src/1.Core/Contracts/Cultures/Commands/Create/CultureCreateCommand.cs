using Core.Domain.Cultures.Parameters;
using System.ComponentModel;
using Zamin.Core.RequestResponse.Commands;

namespace Core.Contracts.Cultures.Commands.Create;

public sealed record CultureCreateCommand : ICommand<Guid>
{
    [Description("The unique key for the culture.")]
    public string Key { get; init; } = default!;

    [Description("The Latin title for the culture.")]
    public string LatinTitle { get; init; } = default!;

    public CultureCreateParameter ToParameter() => new(Key, LatinTitle);
}