using Core.Contracts.Translations.Queries;
using Core.Contracts.Translations.Queries.GetLocalizations;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Core.ApplicationService.Translations.Queries.GetLocalizations;
public sealed class TranslationGetLocalizationsHandler(ZaminServices zaminServices, ITranslationQueryRepository queryRepository)
    : QueryHandler<TranslationGetLocalizationsQuery, List<TranslationLocalizationItemQr>>(zaminServices)
{
    public override async Task<QueryResult<List<TranslationLocalizationItemQr>>> Handle(TranslationGetLocalizationsQuery query)
    {
        return Result(await queryRepository.ExecuteAsync(query));
    }
}