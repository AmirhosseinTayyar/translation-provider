using Core.Domain.Common.Consts;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Core.Domain.Common.ValueObjects;

public sealed class Name : BaseValueObject<Name>
{
    #region Constants
    public const string NAME = nameof(NAME);
    public const int MIN_LENGTH = 1;
    public const int MAX_LENGTH = 128;
    #endregion

    #region Properties
    public string Value { get; private set; } = default!;
    #endregion

    #region Constructors and Factories
    private Name(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static Name FromString(string value) => new(value);
    #endregion

    #region Validations
    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, NAME);
        }

        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            throw new InvalidValueObjectStateException(ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                       NAME,
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

    public static explicit operator string(Name name) => name.Value;

    public static explicit operator Name(string value) => new(value);
    #endregion
}