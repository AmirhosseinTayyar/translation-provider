namespace Core.Domain.Translations.Parameters;

public sealed record TranslationCreateParameter(string Key, string Value, string Culture);