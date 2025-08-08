using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace TranslationProvider.Core.Domain.Common.Guards;

public static class ValueObjectGuard
{
    public static void ThrowIfNull<TValueObject>(this TValueObject value, params string[] parameters)
        where TValueObject : BaseValueObject<TValueObject>
    {
        if (value is null)
            throw new InvalidEntityStateException(ProjectValidationError.VALIDATION_ERROR_REQUIRED_VALUE, parameters);
    }
}