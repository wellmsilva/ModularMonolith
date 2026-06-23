using ModularMonolith.Core.Events;

namespace ModularMonolith.Contracts.Events;

public sealed record ProductCreatedEvent(
    Guid ProductId,
    string Name,
    decimal Price)
    : IDomainEvent
{
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
}