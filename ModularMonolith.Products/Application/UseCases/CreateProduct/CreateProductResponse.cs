namespace ModularMonolith.Products.Application.UseCases.CreateProduct;

public sealed record CreateProductResponse(
    Guid Id,
    string Name,
    decimal Price,
    int StockQuantity);
