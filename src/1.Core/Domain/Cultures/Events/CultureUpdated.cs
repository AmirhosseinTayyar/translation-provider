using Zamin.Core.Domain.Events;

namespace TranslationProvider.Core.Domain.Cultures.Events;

public sealed record CultureUpdated(Guid BusinessId, string Key, string LatinTitle) : IDomainEvent;