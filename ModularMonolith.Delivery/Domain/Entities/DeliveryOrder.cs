using ModularMonolith.Core.Domain;

namespace ModularMonolith.Delivery.Domain.Entities;

public sealed class DeliveryOrder : Entity { 
    public Guid OrderId { get; private set; }
    public string Address { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty; 
    private DeliveryOrder() { }
    public DeliveryOrder(Guid orderId, string address)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        Address = address;
    }
}