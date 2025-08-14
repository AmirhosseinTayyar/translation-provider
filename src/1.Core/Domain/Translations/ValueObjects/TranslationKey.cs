using Core.Domain.Common.Consts;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Core.Domain.Translations.ValueObjects;

public sealed class TranslationKey : BaseValueObject<TranslationKey>
{
    #region Constants
    public const string TRANSLATION_KEY = nameof(TRANSLATION_KEY);
    public const int MIN_LENGTH = 1;
    public const int MAX_LENGTH = 2048;
    #endregion

    #region Properties
    public string Value { get; private set; } = default!;
    #endregion

    #region Constructors and Factories
    private TranslationKey(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static TranslationKey FromString(string value) => new(value);
    #endregion

    #region Validations
    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, TRANSLATION_KEY);
        }

        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                       TRANSLATION_KEY,
                                                       MIN_LENGTH.ToString(),
                                                       MAX_LENGTH.ToString());
        }

        if (!value.All(c => char.IsUpper(c) || char.IsDigit(c) || c == '_'))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, TRANSLATION_KEY);
        }
    }
    #endregion

    #region Override
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static explicit operator string(TranslationKey translationKey) => translationKey.Value;

    public static explicit operator TranslationKey(string value) => new(value);
    #endregion
}
