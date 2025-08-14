using Core.Domain.Common.Consts;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Core.Domain.Common.ValueObjects;

public sealed class LatinTitle : BaseValueObject<LatinTitle>
{
    #region Constants
    public const string LATIN_TITLE = nameof(LATIN_TITLE);
    public const int MIN_LENGTH = 2;
    public const int MAX_LENGTH = 32;
    #endregion

    #region Properties
    public string Value { get; private set; } = default!;
    #endregion

    #region Constructors and Factories
    private LatinTitle(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static LatinTitle FromString(string value) => new(value);
    #endregion

    #region Validations
    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, LATIN_TITLE);
        }

        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                       LATIN_TITLE,
                                                       MIN_LENGTH.ToString(),
                                                       MAX_LENGTH.ToString());
        }

        // Validate that the title follows uppercase format with underscores for multi-word
        if (!value.All(c => char.IsUpper(c) || char.IsDigit(c) || c == '_'))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, LATIN_TITLE);
        }
    }
    #endregion

    #region Override
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static explicit operator string(LatinTitle latinTitle) => latinTitle.Value;

    public static explicit operator LatinTitle(string value) => new(value);
    #endregion
}
