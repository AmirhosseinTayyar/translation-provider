using System.Globalization;
using TranslationProvider.Core.Domain.Common.Resources;
using TranslationProvider.Core.Domain.Cultures.Events;
using TranslationProvider.Core.Domain.Cultures.Parameters;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace TranslationProvider.Core.Domain.Cultures.Entities;

public sealed class Culture : AggregateRoot<int>
{
    #region Constants
    public const string CULTURE = nameof(CULTURE);
    public const string KEY = nameof(KEY);
    public const string LATIN_TITLE = nameof(LATIN_TITLE);
    public const int KEY_MIN_LENGTH = 5;
    public const int KEY_MAX_LENGTH = 10;
    public const int LATIN_TITLE_MIN_LENGTH = 2;
    public const int LATIN_TITLE_MAX_LENGTH = 32;
    #endregion

    #region Properties
    public string Key { get; private set; } = default!;
    public string LatinTitle { get; private set; } = default!;
    public bool IsEnabled { get; private set; }
    #endregion

    #region Constructors
    private Culture() { }

    private Culture(CultureCreateParameter parameter)
    {
        ValidateCultureKey(parameter.Key);

        BusinessId = Zamin.Core.Domain.ValueObjects.BusinessId.FromGuid(Guid.CreateVersion7());
        Key = parameter.Key;
        LatinTitle = parameter.LatinTitle;
        IsEnabled = true;

        AddEvent(new CultureCreated(BusinessId.Value, Key, LatinTitle, IsEnabled));
    }
    #endregion

    #region Commands
    public static Culture Create(CultureCreateParameter parameter) => new(parameter);

    public void Update(CultureUpdateParameter parameter)
    {
        ValidateCultureKey(parameter.Key);

        Key = parameter.Key;
        LatinTitle = parameter.LatinTitle;

        AddEvent(new CultureUpdated(BusinessId.Value, Key, LatinTitle));
    }

    public void Enable()
    {
        IsEnabled = true;

        AddEvent(new CultureEnabled(BusinessId.Value, IsEnabled));
    }

    public void Disable()
    {
        IsEnabled = false;

        AddEvent(new CultureDisabled(BusinessId.Value, IsEnabled));
    }

    public void Delete()
    {
        AddEvent(new CultureDeleted(BusinessId.Value));
    }
    #endregion

    #region Validation
    private static void ValidateCultureKey(string key)
    {
        var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
            .Where(c => !string.IsNullOrWhiteSpace(c.Name))
            .Select(c => c.Name)
            .ToList();

        if (!cultures.Any(culture => culture.Equals(key)))
        {
            throw new InvalidEntityStateException(ProjectValidationError.VALIDATION_ERROR_NOT_VALID,
                                                  KEY,
                                                  CULTURE);
        }
    }
    #endregion
}