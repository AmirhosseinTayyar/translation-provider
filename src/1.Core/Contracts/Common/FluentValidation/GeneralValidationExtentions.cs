using FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Common.FluentValidation;

public static class GeneralValidationExtentions
{
    /// <summary>
    /// VALIDATION_ERROR_REQUIRED
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> PrjectNotNull<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.NotNull()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, name]);

    /// <summary>
    /// VALIDATION_ERROR_REQUIRED
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> PrjectNotEmpty<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.NotEmpty()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, name]);

    /// <summary>
    /// VALIDATION_ERROR_NOT_VALID
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> PrjectIsEnum<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name)
        => ruleBuilder.IsInEnum()
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_VALID, name]);
}