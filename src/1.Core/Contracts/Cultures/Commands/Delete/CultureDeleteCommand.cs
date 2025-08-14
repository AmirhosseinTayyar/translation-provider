using System.ComponentModel;
using Zamin.Core.RequestResponse.Commands;

namespace Core.Contracts.Cultures.Commands.Delete;

public sealed record CultureDeleteCommand : ICommand
{
    [Description("The BusinessId of the culture to delete.")]
    public Guid BusinessId { get; init; }
}