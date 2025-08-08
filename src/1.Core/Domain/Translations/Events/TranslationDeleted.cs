using Zamin.Core.Domain.Events;

namespace TranslationProvider.Core.Domain.Translations.Events;

public sealed record TranslationDeleted(Guid BusinessId) : IDomainEvent;