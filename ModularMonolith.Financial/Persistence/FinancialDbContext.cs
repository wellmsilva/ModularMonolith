using Microsoft.EntityFrameworkCore;
using ModularMonolith.Financial.Domain.Entities;

namespace ModularMonolith.Financial.Persistence;

public sealed class FinancialDbContext(DbContextOptions<FinancialDbContext> options) : DbContext(options) {
    public DbSet<Invoice> Invoices => Set<Invoice>(); 
}
