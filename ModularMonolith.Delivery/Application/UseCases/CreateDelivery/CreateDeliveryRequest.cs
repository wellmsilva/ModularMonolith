namespace ModularMonolith.Delivery.Application.UseCases.CreateDelivery;

public record CreateDeliveryRequest
{
    public Guid OrderId { get; set; }
    public string Address { get; set; } = string.Empty;
}
