using Zamin.Core.RequestResponse.Queries;

namespace TranslationProvider.Core.Contracts.Cultures.Queries.GetSelectList;

public sealed record CultureGetSelectListQuery : IQuery<List<CultureSelectItemQr>>
{
}