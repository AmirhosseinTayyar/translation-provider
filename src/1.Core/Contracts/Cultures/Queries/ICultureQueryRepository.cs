using TranslationProvider.Core.Contracts.Cultures.Queries.GetById;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetFilterablePaged;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetSelectList;
using Zamin.Core.RequestResponse.Queries;

namespace TranslationProvider.Core.Contracts.Cultures.Queries;

public interface ICultureQueryRepository
{
    Task<CultureQr?> ExecuteAsync(CultureGetByIdQuery query);

    Task<List<CultureSelectItemQr>> ExecuteAsync(CultureGetSelectListQuery query);

    Task<PagedData<CulturePageItemQr>> ExecuteAsync(CultureGetFilterablePagedQuery query);
}