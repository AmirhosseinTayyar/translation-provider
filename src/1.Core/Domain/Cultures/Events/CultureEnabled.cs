using Zamin.Core.Domain.Events;

namespace TranslationProvider.Core.Domain.Cultures.Events;

public sealed record CultureEnabled(Guid BusinessId, bool IsEnabled) : IDomainEvent;
