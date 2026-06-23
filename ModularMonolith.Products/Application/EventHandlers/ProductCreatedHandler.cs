using ModularMonolith.Contracts.Events;
using ModularMonolith.Core.Events;

namespace ModularMonolith.Products.Application.EventHandlers;

internal sealed class ProductCreatedHandler : IDomainEventHandler<ProductCreatedEvent>
{
    public Task HandleAsync(ProductCreatedEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Produto criado: {domainEvent.Name}");

        return Task.CompletedTask;
    }
}
