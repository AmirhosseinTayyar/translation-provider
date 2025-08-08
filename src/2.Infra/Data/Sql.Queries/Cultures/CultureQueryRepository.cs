using Microsoft.EntityFrameworkCore;
using TranslationProvider.Core.Contracts.Cultures.Queries;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetById;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetFilterablePaged;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetSelectList;
using TranslationProvider.Infra.Data.Sql.Queries.Common;
using TranslationProvider.Infra.Data.Sql.Queries.Cultures.Entities;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Infra.Data.Sql.Queries;

namespace TranslationProvider.Infra.Data.Sql.Queries.Cultures;

public sealed class CultureQueryRepository(TranslationProviderQueryDbContext dbContext, ITranslator translator)
    : BaseQueryRepository<TranslationProviderQueryDbContext>(dbContext), ICultureQueryRepository
{
    private readonly ITranslator _translator = translator;

    public async Task<CultureQr?> ExecuteAsync(CultureGetByIdQuery query)
    {
        var data = await _dbContext.Set<Culture>()
            .Where(culture => culture.BusinessId == query.BusinessId)
            .Select(culture => (CultureQr)culture)
            .FirstOrDefaultAsync();

        if (data is not null)
            data.LatinTitleTranslated = _translator[data.LatinTitleTranslated];

        return data;
    }

    public async Task<List<CultureSelectItemQr>> ExecuteAsync(CultureGetSelectListQuery query)
    {
        var data = await _dbContext.Set<Culture>()
            .Select(culture => (CultureSelectItemQr)culture)
            .ToListAsync();

        data.ForEach(culture => culture.LatinTitleTranslated = _translator[culture.LatinTitleTranslated]);

        return data;
    }

    public async Task<PagedData<CulturePageItemQr>> ExecuteAsync(CultureGetFilterablePagedQuery query)
    {
        var filter = _dbContext.Set<Culture>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Key))
        {
            filter = filter.Where(c => c.Key.Equals(query.Key));
        }

        if (!string.IsNullOrWhiteSpace(query.LatinTitle))
        {
            filter = filter.Where(c => c.LatinTitle.Equals(query.LatinTitle));
        }

        var data = await filter.ToPagedData(query, Culture => (CulturePageItemQr)Culture);

        data.QueryResult.ForEach(culture => culture.LatinTitleTranslated = _translator[culture.LatinTitleTranslated]);

        return data;
    }
}