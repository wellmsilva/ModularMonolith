using ModularMonolith.Contracts.Events;
using ModularMonolith.Core.Abstractions;
using ModularMonolith.Core.Events;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Persistence;

namespace ModularMonolith.Products.Application.UseCases.CreateProduct;

internal sealed class CreateProductUseCase(ProductsDbContext context, IDomainEventDispatcher eventDispatcher)
    : IUseCase<CreateProductRequest, CreateProductResponse>
{
    public async Task<CreateProductResponse> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        var product = new Product(
            request.Name,
            request.Price,
            request.StockQuantity);

        context.Products.Add(product);

        await context.SaveChangesAsync(cancellationToken);

        await eventDispatcher.PublishAsync(
            new ProductCreatedEvent(
                product.Id,
                product.Name,
                product.Price), cancellationToken);

        return new CreateProductResponse(
            product.Id,
            product.Name,
            product.Price,
            product.StockQuantity);
    }
}