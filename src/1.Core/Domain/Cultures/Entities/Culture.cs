using Core.Domain.Common.ValueObjects;
using Core.Domain.Cultures.Events;
using Core.Domain.Cultures.Parameters;
using Zamin.Core.Domain.Entities;

namespace Core.Domain.Cultures.Entities;

public sealed class Culture : AggregateRoot<int>
{
    #region Constants
    public const string CULTURE = nameof(CULTURE);
    #endregion

    #region Properties
    public CultureKey Key { get; private set; } = default!;
    public LatinTitle LatinTitle { get; private set; } = default!;
    public IsEnabled IsEnabled { get; private set; } = default!;
    #endregion

    #region Constructors
    private Culture() { }

    private Culture(CultureCreateParameter parameter)
    {
        BusinessId = Zamin.Core.Domain.ValueObjects.BusinessId.FromGuid(Guid.CreateVersion7());
        Key = CultureKey.FromString(parameter.Key);
        LatinTitle = LatinTitle.FromString(parameter.LatinTitle);
        IsEnabled = IsEnabled.Enabled();

        AddEvent(new CultureCreated(BusinessId.Value, Key.Value, LatinTitle.Value, IsEnabled.Value));
    }
    #endregion

    #region Commands
    public static Culture Create(CultureCreateParameter parameter) => new(parameter);

    public void Update(CultureUpdateParameter parameter)
    {
        Key = CultureKey.FromString(parameter.Key);
        LatinTitle = LatinTitle.FromString(parameter.LatinTitle);

        AddEvent(new CultureUpdated(BusinessId.Value, Key.Value, LatinTitle.Value));
    }

    public void Enable()
    {
        IsEnabled = IsEnabled.Enabled();

        AddEvent(new CultureEnabled(BusinessId.Value, IsEnabled.Value));
    }

    public void Disable()
    {
        IsEnabled = IsEnabled.Disabled();

        AddEvent(new CultureDisabled(BusinessId.Value, IsEnabled.Value));
    }

    public void Delete()
    {
        AddEvent(new CultureDeleted(BusinessId.Value));
    }
    #endregion
}