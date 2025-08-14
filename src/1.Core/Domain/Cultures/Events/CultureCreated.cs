using Zamin.Core.Domain.Events;

namespace Core.Domain.Cultures.Events;

public sealed record CultureCreated(Guid BusinessId, string Key, string LatinTitle, bool IsEnabled) : IDomainEvent;