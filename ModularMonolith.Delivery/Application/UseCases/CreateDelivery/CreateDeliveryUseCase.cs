using Microsoft.Extensions.Logging;
using ModularMonolith.Core.Abstractions;
using ModularMonolith.Delivery.Domain.Entities;
using ModularMonolith.Delivery.Persistence;

namespace ModularMonolith.Delivery.Application.UseCases.CreateDelivery;

internal sealed class CreateDeliveryUseCase(ILogger<CreateDeliveryUseCase> logger, DeliveryDbContext context) : IUseCase<CreateDeliveryRequest, CreateDeliveryResponse>
{
    public async Task<CreateDeliveryResponse> ExecuteAsync(CreateDeliveryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var delivery = new DeliveryOrder(request.OrderId, request.Address);

            context.Deliveries.Add(delivery);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateDeliveryResponse(delivery.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating a delivery.");
            throw;
        }
    }
}