using Core.Contracts.Cultures.Queries;
using Core.Contracts.Cultures.Queries.GetSelectList;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Core.ApplicationService.Cultures.Queries.GetSelectList;

public sealed class CultureGetSelectListHandler(ZaminServices zaminServices, ICultureQueryRepository queryRepository)
    : QueryHandler<CultureGetSelectListQuery, List<CultureSelectItemQr>>(zaminServices)
{
    public override async Task<QueryResult<List<CultureSelectItemQr>>> Handle(CultureGetSelectListQuery query)
    {
        return Result(await queryRepository.ExecuteAsync(query));
    }
}