using System.ComponentModel;
using Zamin.Core.RequestResponse.Queries;

namespace Core.Contracts.Cultures.Queries.GetById;

public sealed record CultureGetByIdQuery : IQuery<CultureQr?>
{
    [Description("The BusinessId of the culture to retrieve.")]
    public Guid BusinessId { get; init; }
}