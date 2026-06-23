using ModularMonolith.Core.Domain;

namespace ModularMonolith.Financial.Domain.Entities;

public sealed class Invoice : Entity {
    public Guid OrderId { get; private set; } 
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; } 
    private Invoice() { } 

    public Invoice(Guid orderId, decimal amount) 
    {
        OrderId = orderId;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }
}