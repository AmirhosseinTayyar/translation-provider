using FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Common.FluentValidation;

public static class DateValidationExtentions
{
    /// <summary>
    /// Validates that the date is less than the specified date.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN error message.
    /// Persian: بررسی می‌کند که تاریخ کمتر از تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectLessThan<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.LessThan(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the nullable date is less than the specified date.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN error message.
    /// Persian: بررسی می‌کند که تاریخ nullable کمتر از تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectLessThan<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.LessThan(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the date is less than or equal to the specified date.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL error message.
    /// Persian: بررسی می‌کند که تاریخ کمتر یا مساوی تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectLessThanOrEqualTo<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.LessThanOrEqualTo(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the nullable date is less than or equal to the specified date.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL error message.
    /// Persian: بررسی می‌کند که تاریخ nullable کمتر یا مساوی تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectLessThanOrEqualTo<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.LessThanOrEqualTo(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the date is less than today.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ کمتر از امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectLessThanToday<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.LessThan(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY, name]);

    /// <summary>
    /// Validates that the nullable date is less than today.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ nullable کمتر از امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectLessThanToday<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.LessThan(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY, name]);

    /// <summary>
    /// Validates that the date is less than or equal to today.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ کمتر یا مساوی امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectLessThanOrEqualToday<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.LessThanOrEqualTo(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY, name]);

    /// <summary>
    /// Validates that the nullable date is less than or equal to today.
    /// Uses VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ nullable کمتر یا مساوی امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectLessThanOrEqualToday<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.LessThanOrEqualTo(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY, name]);

    /// <summary>
    /// Validates that the date is greater than the specified date.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN error message.
    /// Persian: بررسی می‌کند که تاریخ بزرگتر از تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectGreaterThan<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.GreaterThan(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the nullable date is greater than the specified date.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN error message.
    /// Persian: بررسی می‌کند که تاریخ nullable بزرگتر از تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectGreaterThan<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.GreaterThan(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the date is greater than or equal to the specified date.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL error message.
    /// Persian: بررسی می‌کند که تاریخ بزرگتر یا مساوی تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectGreaterThanOrEqualTo<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.GreaterThanOrEqualTo(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the nullable date is greater than or equal to the specified date.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL error message.
    /// Persian: بررسی می‌کند که تاریخ nullable بزرگتر یا مساوی تاریخ مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectGreaterThanOrEqualTo<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name, DateTime dateToCompare)
        => ruleBuilder.GreaterThanOrEqualTo(dateToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL,
                                name,
                                dateToCompare.ToString("yyyy/MM/dd")]);

    /// <summary>
    /// Validates that the date is greater than today.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ بزرگتر از امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectGreaterThanToday<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.GreaterThan(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY, name]);

    /// <summary>
    /// Validates that the nullable date is greater than today.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ nullable بزرگتر از امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectGreaterThanToday<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.GreaterThan(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY, name]);

    /// <summary>
    /// Validates that the date is greater than or equal to today.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ بزرگتر یا مساوی امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime> ProjectGreaterThanOrEqualToday<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.GreaterThanOrEqualTo(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY, name]);

    /// <summary>
    /// Validates that the nullable date is greater than or equal to today.
    /// Uses VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY error message.
    /// Persian: بررسی می‌کند که تاریخ nullable بزرگتر یا مساوی امروز باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, DateTime?> ProjectGreaterThanOrEqualToday<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.GreaterThanOrEqualTo(DateTime.Today)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY, name]);
}