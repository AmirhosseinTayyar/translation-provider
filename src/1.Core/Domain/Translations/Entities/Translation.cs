using TranslationProvider.Core.Domain.Common.ValueObjects;
using TranslationProvider.Core.Domain.Translations.Events;
using TranslationProvider.Core.Domain.Translations.Parameters;
using TranslationProvider.Core.Domain.Translations.ValueObjects;
using Zamin.Core.Domain.Entities;

namespace TranslationProvider.Core.Domain.Translations.Entities;

public sealed class Translation : AggregateRoot<int>
{
    #region Constants
    public const string TRANSLATION = nameof(TRANSLATION);
    #endregion

    #region Properties
    public TranslationKey Key { get; private set; } = default!;
    public TranslationValue Value { get; private set; } = default!;
    public CultureKey Culture { get; private set; } = default!;
    #endregion

    #region Constructors
    private Translation() { }

    private Translation(TranslationCreateParameter parameter)
    {
        BusinessId = Zamin.Core.Domain.ValueObjects.BusinessId.FromGuid(Guid.CreateVersion7());
        Key = TranslationKey.FromString(parameter.Key);
        Value = TranslationValue.FromString(parameter.Value);
        Culture = CultureKey.FromString(parameter.Culture);
        AddEvent(new TranslationCreated(BusinessId.Value, (string)Key, (string)Value, (string)Culture));
    }
    #endregion

    #region Commands
    public static Translation Create(TranslationCreateParameter parameter) => new(parameter);

    public void Update(TranslationUpdateParameter parameter)
    {
        Key = TranslationKey.FromString(parameter.Key);
        Value = TranslationValue.FromString(parameter.Value);
        Culture = CultureKey.FromString(parameter.Culture);
        AddEvent(new TranslationUpdated(BusinessId.Value, (string)Key, (string)Value, (string)Culture));
    }

    public void Delete()
    {
        AddEvent(new TranslationDeleted(BusinessId.Value));
    }
    #endregion
}