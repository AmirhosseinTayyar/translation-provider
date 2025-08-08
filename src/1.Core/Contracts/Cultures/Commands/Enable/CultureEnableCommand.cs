using System.ComponentModel;
using Zamin.Core.RequestResponse.Commands;

namespace TranslationProvider.Core.Contracts.Cultures.Commands.Enable;

public sealed record CultureEnableCommand : ICommand
{
    [Description("The BusinessId of the culture to enable.")]
    public Guid BusinessId { get; init; }
}
