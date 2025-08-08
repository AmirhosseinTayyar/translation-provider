using FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Common.FluentValidation;

public static class GeneralValidationExtentions
{
    /// <summary>
    /// Validates that the property is not null.
    /// Uses VALIDATION_ERROR_REQUIRED error message.
    /// Persian: بررسی می‌کند که ویژگی null نباشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectNotNull<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.NotNull()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, name]);

    /// <summary>
    /// Validates that the property is not empty.
    /// Uses VALIDATION_ERROR_REQUIRED error message.
    /// Persian: بررسی می‌کند که ویژگی خالی نباشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectNotEmpty<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.NotEmpty()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, name]);

    /// <summary>
    /// Validates that the property is a valid enum value.
    /// Uses VALIDATION_ERROR_NOT_VALID error message.
    /// Persian: بررسی می‌کند که ویژگی یک مقدار enum معتبر باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectIsEnum<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.IsInEnum()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_VALID, name]);

    /// <summary>
    /// Validates that the property must be null.
    /// Uses VALIDATION_ERROR_NOT_VALID error message.
    /// Persian: بررسی می‌کند که ویژگی باید null باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectMustBeNull<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Null()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_VALID, name]);

    /// <summary>
    /// Validates that the property must be empty.
    /// Uses VALIDATION_ERROR_NOT_VALID error message.
    /// Persian: بررسی می‌کند که ویژگی باید خالی باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectMustBeEmpty<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Empty()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_VALID, name]);

    /// <summary>
    /// Custom validation predicate.
    /// Uses VALIDATION_ERROR_NOT_VALID error message.
    /// Persian: اعتبارسنجی سفارشی با استفاده از predicate.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectMust<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, Func<TProperty, bool> predicate)
        => ruleBuilder.Must(predicate)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_VALID, name]);
}