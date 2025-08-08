using Zamin.Core.RequestResponse.Commands;
using System.ComponentModel;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Delete;

public sealed record TranslationDeleteCommand : ICommand
{
    [Description("The business identifier for the translation to delete.")]
    public Guid BusinessId { get; init; }
}