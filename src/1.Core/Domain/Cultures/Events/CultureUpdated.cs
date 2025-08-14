using Zamin.Core.Domain.Events;

namespace Core.Domain.Cultures.Events;

public sealed record CultureUpdated(Guid BusinessId, string Key, string LatinTitle) : IDomainEvent;