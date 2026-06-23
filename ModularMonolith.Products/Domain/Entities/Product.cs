using ModularMonolith.Core.Domain;

namespace ModularMonolith.Products.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int StockQuantity { get; private set; }

    private Product()
    {
    }

    public Product(
        string name,
        decimal price,
        int stockQuantity)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }
}