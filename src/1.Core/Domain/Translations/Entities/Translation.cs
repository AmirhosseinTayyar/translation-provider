using TranslationProvider.Core.Domain.Translations.Events;
using TranslationProvider.Core.Domain.Translations.Parameters;
using Zamin.Core.Domain.Entities;

namespace TranslationProvider.Core.Domain.Translations.Entities;

public sealed class Translation : AggregateRoot<int>
{
    #region Constants
    public const string TRANSLATION = nameof(TRANSLATION);
    public const string KEY = nameof(KEY);
    public const string VALUE = nameof(VALUE);
    public const string CULTURE = nameof(CULTURE);
    public const int KEY_MIN_LENGTH = 1;
    public const int KEY_MAX_LENGTH = 2048;
    public const int VALUE_MIN_LENGTH = 1;
    public const int VALUE_MAX_LENGTH = 2048;
    #endregion

    #region Properties
    public string Key { get; private set; } = default!;
    public string Value { get; private set; } = default!;
    public string Culture { get; private set; } = default!;
    #endregion

    #region Constructors
    private Translation() { }

    private Translation(TranslationCreateParameter parameter)
    {
        BusinessId = Zamin.Core.Domain.ValueObjects.BusinessId.FromGuid(Guid.CreateVersion7());
        Key = parameter.Key;
        Value = parameter.Value;
        Culture = parameter.Culture;
        AddEvent(new TranslationCreated(BusinessId.Value, Key, Value, Culture));
    }
    #endregion

    #region Commands
    public static Translation Create(TranslationCreateParameter parameter) => new(parameter);

    public void Update(TranslationUpdateParameter parameter)
    {
        Key = parameter.Key;
        Value = parameter.Value;
        Culture = parameter.Culture;
        AddEvent(new TranslationUpdated(BusinessId.Value, Key, Value, Culture));
    }

    public void Delete()
    {
        AddEvent(new TranslationDeleted(BusinessId.Value));
    }
    #endregion
}