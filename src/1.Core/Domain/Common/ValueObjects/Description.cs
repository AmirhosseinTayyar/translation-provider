using Core.Domain.Common.Consts;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Core.Domain.Common.ValueObjects;

public sealed class Description : BaseValueObject<Description>
{
    #region Constants
    public const string DESCRIPTION = nameof(DESCRIPTION);
    public const int MIN_LENGTH = 1;
    public const int MAX_LENGTH = 1024;
    #endregion

    #region Properties
    public string Value { get; private set; } = default!;
    #endregion

    #region Constructors and Factories
    private Description(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static Description FromString(string value) => new(value);
    #endregion

    #region Validations
    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, DESCRIPTION);
        }

        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                       DESCRIPTION,
                                                       MIN_LENGTH.ToString(),
                                                       MAX_LENGTH.ToString());
        }
    }
    #endregion

    #region Override
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static explicit operator string(Description description) => description.Value;

    public static explicit operator Description(string value) => new(value);
    #endregion
}