using TranslationProvider.Core.Contracts.Translations.Queries.GetById;
using TranslationProvider.Core.Contracts.Translations.Queries.GetFilterablePaged;
using TranslationProvider.Core.Contracts.Translations.Queries.GetLocalizations;
using Zamin.Core.RequestResponse.Queries;

namespace TranslationProvider.Core.Contracts.Translations.Queries;

public interface ITranslationQueryRepository
{
    Task<TranslationQr?> ExecuteAsync(TranslationGetByIdQuery query);

    Task<PagedData<TranslationListItemQr>> ExecuteAsync(TranslationGetFilterablePagedQuery query);

    Task<List<TranslationLocalizationItemQr>> ExecuteAsync(TranslationGetLocalizationsQuery query);
}