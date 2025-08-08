using Zamin.Core.Domain.Events;

namespace TranslationProvider.Core.Domain.Translations.Events;

public sealed record TranslationUpdated(Guid BusinessId,
                                        string Key,
                                        string Value,
                                        string Culture) : IDomainEvent;