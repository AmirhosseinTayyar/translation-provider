using Core.Domain.Common.Consts;
using FluentValidation;
using System.Text.RegularExpressions;
using Zamin.Extensions.Translations.Abstractions;

namespace Core.Contracts.Common.FluentValidation;

public static class StringValidationExtentions
{
    /// <summary>
    /// Validates string length is between min and max values.
    /// Uses VALIDATION_ERROR_STRING_LENGTH_BETWEEN error message.
    /// Persian: بررسی می‌کند که طول رشته بین حداقل و حداکثر مقدار باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectLength<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, int min, int max)
        => ruleBuilder.Length(min, max)
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                name, min.ToString(),
                                max.ToString()]);

    /// <summary>
    /// Validates string minimum length.
    /// Uses VALIDATION_ERROR_STRING_MIN_LENGTH error message.
    /// Persian: بررسی می‌کند که طول رشته حداقل برابر مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMinimumLength<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, int minLength)
        => ruleBuilder.MinimumLength(minLength)
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MIN_LENGTH,
                                name, minLength.ToString()]);

    /// <summary>
    /// Validates string maximum length.
    /// Uses VALIDATION_ERROR_STRING_MAX_LENGTH error message.
    /// Persian: بررسی می‌کند که طول رشته حداکثر برابر مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMaximumLength<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, int maxLength)
        => ruleBuilder.MaximumLength(maxLength)
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MAX_LENGTH,
                                name, maxLength.ToString()]);

    /// <summary>
    /// Validates string exact length.
    /// Uses VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL error message.
    /// Persian: بررسی می‌کند که طول رشته دقیقاً برابر مقدار مشخص شده باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectExactLength<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, int exactLength)
        => ruleBuilder.Length(exactLength)
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL,
                                name, exactLength.ToString()]);

    /// <summary>
    /// Validates string contains at least one uppercase letter.
    /// Uses VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE error message.
    /// Persian: بررسی می‌کند که رشته حداقل یک حرف بزرگ داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMustHaveUpperCase<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Must(s => !string.IsNullOrEmpty(s) && s.Any(char.IsUpper))
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE, name]);

    /// <summary>
    /// Validates string contains at least one lowercase letter.
    /// Uses VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE error message.
    /// Persian: بررسی می‌کند که رشته حداقل یک حرف کوچک داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMustHaveLowerCase<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Must(s => !string.IsNullOrEmpty(s) && s.Any(char.IsLower))
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE, name]);

    /// <summary>
    /// Validates string contains at least one digit.
    /// Uses VALIDATION_ERROR_STRING_MUST_HAS_DIGIT error message.
    /// Persian: بررسی می‌کند که رشته حداقل یک عدد داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMustHaveDigit<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Must(s => !string.IsNullOrEmpty(s) && s.Any(char.IsDigit))
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MUST_HAS_DIGIT, name]);

    /// <summary>
    /// Validates string contains at least one non-alphanumeric character.
    /// Uses VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC error message.
    /// Persian: بررسی می‌کند که رشته حداقل یک کاراکتر غیر حرف و عدد داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMustHaveNonAlphanumeric<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Must(s => !string.IsNullOrEmpty(s) && s.Any(c => !char.IsLetterOrDigit(c)))
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC, name]);

    /// <summary>
    /// Validates string contains unique characters only.
    /// Uses VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR error message.
    /// Persian: بررسی می‌کند که رشته فقط کاراکترهای منحصر به فرد داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMustHaveUniqueCharacters<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.Must(s => string.IsNullOrEmpty(s) || s.Length == s.Distinct().Count())
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR, name]);

    /// <summary>
    /// Validates string matches the specified regular expression pattern.
    /// Uses VALIDATION_ERROR_NOT_VALID error message.
    /// Persian: بررسی می‌کند که رشته با الگوی regex مشخص شده مطابقت داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMatches<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, string pattern)
        => ruleBuilder.Matches(pattern)
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, name]);

    /// <summary>
    /// Validates string matches the specified regular expression.
    /// Uses VALIDATION_ERROR_NOT_VALID error message.
    /// Persian: بررسی می‌کند که رشته با regex مشخص شده مطابقت داشته باشد.
    /// </summary>
    public static IRuleBuilderOptions<T, string> ProjectMatches<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, Regex regex)
        => ruleBuilder.Matches(regex)
        .WithMessage(translator[ProjectValidationErrors.VALIDATION_ERROR_NOT_VALID, name]);
}