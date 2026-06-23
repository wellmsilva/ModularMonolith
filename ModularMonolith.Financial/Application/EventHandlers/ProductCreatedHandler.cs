using Microsoft.Extensions.Logging;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Core.Events;
using ModularMonolith.Financial.Domain.Entities;
using ModularMonolith.Financial.Persistence;

namespace ModularMonolith.Financial.Application.EventHandlers;

internal sealed class ProductCreatedHandler(ILogger<ProductCreatedHandler> logger, FinancialDbContext context)    : IDomainEventHandler<ProductCreatedEvent>
{
    public async Task HandleAsync(ProductCreatedEvent domainEvent, CancellationToken cancellationToken = default)
    {
        try
        {
            var invoice = new Invoice(domainEvent.ProductId, domainEvent.Price);

            context.Invoices.Add(invoice);

            await context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error handling ProductCreatedEvent for ProductId: {ProductId}", domainEvent.ProductId);
        }
   
    }
}
