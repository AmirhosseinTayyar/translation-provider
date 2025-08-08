using FluentValidation;
using TranslationProvider.Core.Domain.Common.Resources;
using Zamin.Extensions.Translations.Abstractions;

namespace TranslationProvider.Core.Contracts.Common.FluentValidation;

public static class StringValidationExtentions
{
    /// <summary>
    /// VALIDATION_ERROR_STRING_LENGTH_BETWEEN
    /// </summary>
    public static IRuleBuilderOptions<T, string> PrjectLength<T>(
        this IRuleBuilder<T, string> ruleBuilder, ITranslator translator, string name, int min, int max)
        => ruleBuilder.Length(min, max)
        .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                name, min.ToString(),
                                max.ToString()]);
}