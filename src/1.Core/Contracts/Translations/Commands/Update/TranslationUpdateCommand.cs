using TranslationProvider.Core.Domain.Translations.Parameters;
using Zamin.Core.RequestResponse.Commands;
using System.ComponentModel;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Update;

public sealed record TranslationUpdateCommand : ICommand
{
    [Description("The business identifier for the translation to update.")]
    public Guid BusinessId { get; init; }

    [Description("The unique key for the translation.")]
    public string Key { get; init; } = default!;

    [Description("The value for the translation.")]
    public string Value { get; init; } = default!;

    [Description("The culture for the translation.")]
    public string Culture { get; init; } = default!;

    public TranslationUpdateParameter ToParameter() => new(Key, Value, Culture);
}