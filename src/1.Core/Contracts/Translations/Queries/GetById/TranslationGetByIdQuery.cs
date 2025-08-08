using Zamin.Core.RequestResponse.Queries;
using System.ComponentModel;

namespace TranslationProvider.Core.Contracts.Translations.Queries.GetById;

public sealed record TranslationGetByIdQuery : IQuery<TranslationQr?>
{
    [Description("The business identifier for the translation to retrieve.")]
    public Guid BusinessId { get; init; }
}