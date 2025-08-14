using Core.Contracts.Cultures.Queries.GetById;
using Core.Contracts.Cultures.Queries.GetFilterablePaged;
using Core.Contracts.Cultures.Queries.GetSelectList;

namespace Infra.Data.Sql.Queries.Cultures.Entities;

public sealed class Culture()
{
    #region Properties
    public int Id { get; set; }
    public Guid BusinessId { get; set; }
    public string Key { get; set; } = default!;
    public string LatinTitle { get; set; } = default!;
    public bool IsEnabled { get; set; }
    #endregion

    public static explicit operator CultureQr(Culture entity) => new()
    {
        Id = entity.Id,
        BusinessId = entity.BusinessId,
        Key = entity.Key,
        LatinKey = entity.LatinTitle,
        IsEnabled = entity.IsEnabled
    };

    public static explicit operator CultureSelectItemQr(Culture entity) => new()
    {
        Key = entity.Key,
        IsEnabled = entity.IsEnabled
    };

    public static explicit operator CulturePageItemQr(Culture entity) => new()
    {
        Id = entity.Id,
        BusinessId = entity.BusinessId,
        Key = entity.Key,
        LatinTitle = entity.LatinTitle,
        IsEnabled = entity.IsEnabled
    };
}