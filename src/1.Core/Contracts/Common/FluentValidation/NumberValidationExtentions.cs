using FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Common.FluentValidation;

public static class NumberValidationExtentions
{

    /// <summary>
    /// VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> PrjectGreaterThanOrEqualTo<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThanOrEqualTo(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);

    /// <summary>
    /// VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty?> PrjectGreaterThanOrEqualTo<T, TProperty>(
        this IRuleBuilder<T, TProperty?> ruleBuilder, ITranslator translator, string name, TProperty valueToCompare)
        where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThanOrEqualTo(valueToCompare)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN,
                                name,
                                valueToCompare.ToString() ?? string.Empty]);
}