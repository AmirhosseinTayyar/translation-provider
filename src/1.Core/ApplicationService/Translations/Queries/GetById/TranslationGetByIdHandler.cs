using TranslationProvider.Core.Contracts.Translations.Queries;
using TranslationProvider.Core.Contracts.Translations.Queries.GetById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace TranslationProvider.Core.ApplicationService.Translations.Queries.GetById;

public sealed class TranslationGetByIdHandler(ZaminServices zaminServices, ITranslationQueryRepository queryRepository)
    : QueryHandler<TranslationGetByIdQuery, TranslationQr?>(zaminServices)
{
    public override async Task<QueryResult<TranslationQr?>> Handle(TranslationGetByIdQuery query)
    {
        return Result(await queryRepository.ExecuteAsync(query));
    }
}