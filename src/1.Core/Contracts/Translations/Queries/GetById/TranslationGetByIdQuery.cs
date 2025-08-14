using System.ComponentModel;
using Zamin.Core.RequestResponse.Queries;

namespace Core.Contracts.Translations.Queries.GetById;

public sealed record TranslationGetByIdQuery : IQuery<TranslationQr?>
{
    [Description("The business identifier for the translation to retrieve.")]
    public Guid BusinessId { get; init; }
}