
namespace ModularMonolith.Core.Events;

public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}
