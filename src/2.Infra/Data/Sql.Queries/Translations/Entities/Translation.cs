using TranslationProvider.Core.Contracts.Translations.Queries.GetById;
using TranslationProvider.Core.Contracts.Translations.Queries.GetFilterablePaged;
using TranslationProvider.Core.Contracts.Translations.Queries.GetLocalizations;

namespace TranslationProvider.Infra.Data.Sql.Queries.Translations.Entities;

public sealed class Translation
{
    public int Id { get; set; }
    public Guid BusinessId { get; set; }
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
    public string Culture { get; set; } = default!;

    public static explicit operator TranslationQr(Translation entity) => new()
    {
        Id = entity.Id,
        BusinessId = entity.BusinessId,
        Key = entity.Key,
        Value = entity.Value,
        Culture = entity.Culture
    };

    public static explicit operator TranslationListItemQr(Translation entity) => new()
    {
        Id = entity.Id,
        BusinessId = entity.BusinessId,
        Key = entity.Key,
        Value = entity.Value,
        Culture = entity.Culture
    };

    public static explicit operator TranslationLocalizationItemQr(Translation entity) => new()
    {
        Key = entity.Key,
        Value = entity.Value,
        Culture = entity.Culture
    };
}