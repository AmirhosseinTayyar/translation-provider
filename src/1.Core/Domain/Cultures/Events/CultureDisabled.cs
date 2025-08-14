using Zamin.Core.Domain.Events;

namespace Core.Domain.Cultures.Events;

public sealed record CultureDisabled(Guid BusinessId, bool IsEnabled) : IDomainEvent;