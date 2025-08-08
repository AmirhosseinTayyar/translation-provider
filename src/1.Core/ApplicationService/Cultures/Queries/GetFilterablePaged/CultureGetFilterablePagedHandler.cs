using TranslationProvider.Core.Contracts.Cultures.Queries;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetFilterablePaged;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace TranslationProvider.Core.ApplicationService.Cultures.Queries.GetFilterablePaged;

public sealed class CultureGetFilterablePagedHandler(ZaminServices zaminServices, ICultureQueryRepository queryRepository)
    : QueryHandler<CultureGetFilterablePagedQuery, PagedData<CulturePageItemQr>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<CulturePageItemQr>>> Handle(CultureGetFilterablePagedQuery query)
    {
        return Result(await queryRepository.ExecuteAsync(query));
    }
}