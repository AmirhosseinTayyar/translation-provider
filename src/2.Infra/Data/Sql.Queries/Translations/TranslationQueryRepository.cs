using Core.Contracts.Translations.Queries;
using Core.Contracts.Translations.Queries.GetById;
using Core.Contracts.Translations.Queries.GetFilterablePaged;
using Core.Contracts.Translations.Queries.GetLocalizations;
using Infra.Data.Sql.Queries.Common;
using Infra.Data.Sql.Queries.Translations.Entities;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace Infra.Data.Sql.Queries.Translations;

public class TranslationQueryRepository(TranslationProviderQueryDbContext dbContext)
    : BaseQueryRepository<TranslationProviderQueryDbContext>(dbContext), ITranslationQueryRepository
{
    public async Task<TranslationQr?> ExecuteAsync(TranslationGetByIdQuery query)
    {
        return await _dbContext.Set<Translation>()
            .Where(Translation => Translation.BusinessId == query.BusinessId)
            .Select(Translation => (TranslationQr)Translation)
            .FirstOrDefaultAsync();
    }

    public async Task<PagedData<TranslationListItemQr>> ExecuteAsync(TranslationGetFilterablePagedQuery query)
    {
        var filter = _dbContext.Set<Translation>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Key))
        {
            filter = filter.Where(c => c.Key.Equals(query.Key));
        }

        if (!string.IsNullOrWhiteSpace(query.Value))
        {
            filter = filter.Where(c => c.Value.Contains(query.Value));
        }

        if (!string.IsNullOrWhiteSpace(query.Culture))
        {
            filter = filter.Where(c => c.Culture.Equals(query.Culture));
        }

        return await filter.ToPagedData(query, Translation => (TranslationListItemQr)Translation);
    }

    public async Task<List<TranslationLocalizationItemQr>> ExecuteAsync(TranslationGetLocalizationsQuery query)
        => await _dbContext.Set<Translation>()
        .Select(Translation => (TranslationLocalizationItemQr)Translation)
        .ToListAsync();
}