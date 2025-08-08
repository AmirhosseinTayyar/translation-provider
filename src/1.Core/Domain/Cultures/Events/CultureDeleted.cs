using Zamin.Core.Domain.Events;

namespace TranslationProvider.Core.Domain.Cultures.Events;

public sealed record CultureDeleted(Guid BusinessId) : IDomainEvent;