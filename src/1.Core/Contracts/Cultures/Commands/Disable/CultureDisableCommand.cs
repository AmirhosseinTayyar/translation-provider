using System.ComponentModel;
using Zamin.Core.RequestResponse.Commands;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Disable;

public sealed record CultureDisableCommand : ICommand
{
    [Description("The BusinessId of the culture to disable.")]
    public Guid BusinessId { get; init; }
}