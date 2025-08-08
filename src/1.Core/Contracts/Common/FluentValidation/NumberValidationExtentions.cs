using FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Common.FluentValidation;

public static class NumberValidationExtentions
{
    /// <summary>
    /// Validates that the number equals the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_NOT_EQUAL_TO error message.
    /// Persian: بررسی می‌کند که عدد برابر مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectEqualTo<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.Equal(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_NOT_EQUAL_TO,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the number is between min and max values (inclusive).
    /// Uses VALIDATION_ERROR_NUMBER_BETWEEN error message.
    /// Persian: بررسی می‌کند که عدد بین حداقل و حداکثر مقدار (شامل) باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectInclusiveBetween<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty from, TProperty to)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.InclusiveBetween(from, to)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_BETWEEN,
                                name,
                                from.ToString() ?? string.Empty,
                                to.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the number is between min and max values (exclusive).
    /// Uses VALIDATION_ERROR_NUMBER_BETWEEN error message.
    /// Persian: بررسی می‌کند که عدد بین حداقل و حداکثر مقدار (غیرشامل) باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectExclusiveBetween<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty from, TProperty to)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.ExclusiveBetween(from, to)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_BETWEEN,
                                name,
                                from.ToString() ?? string.Empty,
                                to.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the number is less than the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_LESS_THAN error message.
    /// Persian: بررسی می‌کند که عدد کمتر از مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectLessThan<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.LessThan(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_LESS_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the number is less than or equal to the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN error message.
    /// Persian: بررسی می‌کند که عدد کمتر یا مساوی مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectLessThanOrEqualTo<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.LessThanOrEqualTo(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the number is greater than the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_GRATER_THAN error message.
    /// Persian: بررسی می‌کند که عدد بزرگتر از مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectGreaterThan<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThan(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_GRATER_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the number is greater than or equal to the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN error message.
    /// Persian: بررسی می‌کند که عدد بزرگتر یا مساوی مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> ProjectGreaterThanOrEqualTo<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThanOrEqualTo(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the nullable number is greater than or equal to the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN error message.
    /// Persian: بررسی می‌کند که عدد nullable بزرگتر یا مساوی مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty?> ProjectGreaterThanOrEqualTo<T, TProperty>(
        this IRuleBuilder<T, TProperty?> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThanOrEqualTo(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the nullable number is less than the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_LESS_THAN error message.
    /// Persian: بررسی می‌کند که عدد nullable کمتر از مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty?> ProjectLessThan<T, TProperty>(
        this IRuleBuilder<T, TProperty?> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.LessThan(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_LESS_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// Validates that the nullable number is greater than the specified value.
    /// Uses VALIDATION_ERROR_NUMBER_GRATER_THAN error message.
    /// Persian: بررسی می‌کند که عدد nullable بزرگتر از مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty?> ProjectGreaterThan<T, TProperty>(
        this IRuleBuilder<T, TProperty?> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThan(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_GRATER_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);
}