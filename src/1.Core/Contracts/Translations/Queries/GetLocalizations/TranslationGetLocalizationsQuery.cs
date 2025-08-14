using Zamin.Core.RequestResponse.Queries;

namespace Core.Contracts.Translations.Queries.GetLocalizations;

public sealed record TranslationGetLocalizationsQuery : IQuery<List<TranslationLocalizationItemQr>>
{
}