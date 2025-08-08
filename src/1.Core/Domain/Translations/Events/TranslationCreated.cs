using Zamin.Core.Domain.Events;

namespace TranslationProvider.Core.Domain.Translations.Events;

public sealed record TranslationCreated(Guid BusinessId,
                                        string Key,
                                        string Value,
                                        string Culture) : IDomainEvent;