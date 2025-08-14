using Core.Domain.Common.Consts;
using System.Globalization;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Core.Domain.Common.ValueObjects;

public sealed class CultureKey : BaseValueObject<CultureKey>
{
    #region Constants
    public const string CULTURE_KEY = nameof(CULTURE_KEY);
    public const int MIN_LENGTH = 5;
    public const int MAX_LENGTH = 10;
    #endregion

    #region Properties
    public string Value { get; private set; } = default!;
    #endregion

    #region Constructors and Factories
    private CultureKey(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static CultureKey FromString(string value) => new(value);
    #endregion

    #region Validations
    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, CULTURE_KEY);
        }

        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                       CULTURE_KEY,
                                                       MIN_LENGTH.ToString(),
                                                       MAX_LENGTH.ToString());
        }

        // Validate if the culture key exists in .NET CultureInfo
        var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
            .Where(c => !string.IsNullOrWhiteSpace(c.Name))
            .Select(c => c.Name)
            .ToList();

        if (!cultures.Any(culture => culture.Equals(value)))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, CULTURE_KEY);
        }
    }
    #endregion

    #region Override
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static explicit operator string(CultureKey cultureKey) => cultureKey.Value;

    public static explicit operator CultureKey(string value) => new(value);
    #endregion
}
