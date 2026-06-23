namespace ModularMonolith.Products.Application.UseCases.CreateProduct;

public sealed record CreateProductRequest(
    string Name,
    decimal Price,
    int StockQuantity);