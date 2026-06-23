using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Core.Abstractions;
using ModularMonolith.Products.Application.UseCases.CreateProduct;

namespace ModularMonolith.Api.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    [HttpPost]
    public async Task<CreateProductResponse> Create(
        [FromServices] IUseCase<CreateProductRequest, CreateProductResponse> useCase,
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        return await useCase.ExecuteAsync(request, cancellationToken);
    }
}
