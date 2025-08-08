using System.ComponentModel;
using TranslationProvider.Core.Domain.Translations.Parameters;
using Zamin.Core.RequestResponse.Commands;

namespace TranslationProvider.Core.Contracts.Translations.Commands.Create;

public sealed record TranslationCreateCommand : ICommand<Guid>
{
    [Description("The unique key for the translation.")]
    public string Key { get; init; } = default!;

    [Description("The value for the translation.")]
    public string Value { get; init; } = default!;

    [Description("The culture for the translation.")]
    public string Culture { get; init; } = default!;

    public TranslationCreateParameter ToParameter() => new(Key, Value, Culture);
}