using Zamin.Core.Domain.Events;

namespace Core.Domain.Translations.Events;

public sealed record TranslationDeleted(Guid BusinessId) : IDomainEvent;