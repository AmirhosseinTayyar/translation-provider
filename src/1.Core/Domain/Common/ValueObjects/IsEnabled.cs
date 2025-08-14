using Zamin.Core.Domain.ValueObjects;

namespace Core.Domain.Common.ValueObjects;

public sealed class IsEnabled : BaseValueObject<IsEnabled>
{
    #region Constants
    public const string IS_ENABLED = nameof(IS_ENABLED);
    public const bool DEFAULT_VALUE = true;
    #endregion

    #region Properties
    public bool Value { get; private set; }
    #endregion

    #region Constructors and Factories
    private IsEnabled(bool value)
    {
        Value = value;
    }

    public static IsEnabled FromBoolean(bool value) => new(value);
    public static IsEnabled Enabled() => new(true);
    public static IsEnabled Disabled() => new(false);
    public static IsEnabled Default() => new(DEFAULT_VALUE);
    #endregion

    #region Override
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();

    public static explicit operator bool(IsEnabled isEnabled) => isEnabled.Value;

    public static explicit operator IsEnabled(bool value) => new(value);
    #endregion
}
