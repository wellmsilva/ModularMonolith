using Microsoft.EntityFrameworkCore;
using ModularMonolith.Delivery.Domain.Entities;

namespace ModularMonolith.Delivery.Persistence;

public sealed class DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : DbContext(options) {
    public DbSet<DeliveryOrder> Deliveries => Set<DeliveryOrder>(); 
}