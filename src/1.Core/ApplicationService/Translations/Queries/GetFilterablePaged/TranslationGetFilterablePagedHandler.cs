using Core.Contracts.Translations.Queries;
using Core.Contracts.Translations.Queries.GetFilterablePaged;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Core.ApplicationService.Translations.Queries.GetFilterablePaged;

public sealed class TranslationGetFilterablePagedHandler(ZaminServices zaminServices, ITranslationQueryRepository queryRepository)
    : QueryHandler<TranslationGetFilterablePagedQuery, PagedData<TranslationListItemQr>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<TranslationListItemQr>>> Handle(TranslationGetFilterablePagedQuery query)
    {
        return Result(await queryRepository.ExecuteAsync(query));
    }
}