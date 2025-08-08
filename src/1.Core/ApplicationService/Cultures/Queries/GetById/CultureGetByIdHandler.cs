using TranslationProvider.Core.Contracts.Cultures.Queries;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace TranslationProvider.Core.ApplicationService.Cultures.Queries.GetById;

public sealed class CultureGetByIdHandler(ZaminServices zaminServices, ICultureQueryRepository queryRepository)
    : QueryHandler<CultureGetByIdQuery, CultureQr?>(zaminServices)
{
    public override async Task<QueryResult<CultureQr?>> Handle(CultureGetByIdQuery query)
    {
        return Result(await queryRepository.ExecuteAsync(query));
    }
}