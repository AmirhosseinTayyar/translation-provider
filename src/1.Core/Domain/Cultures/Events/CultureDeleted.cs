using Zamin.Core.Domain.Events;

namespace Core.Domain.Cultures.Events;

public sealed record CultureDeleted(Guid BusinessId) : IDomainEvent;