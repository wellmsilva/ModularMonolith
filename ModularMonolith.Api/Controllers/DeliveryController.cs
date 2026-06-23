using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Core.Abstractions;
using ModularMonolith.Delivery.Application.UseCases.CreateDelivery;

namespace ModularMonolith.Api.Controllers
{
    [ApiController]
    [Route("api/delivery")]

    public class DeliveryController : ControllerBase
    {
        [HttpPost]
        public async Task<CreateDeliveryResponse> Create(
        [FromServices] IUseCase<CreateDeliveryRequest, CreateDeliveryResponse> useCase,
        [FromBody] CreateDeliveryRequest request,
        CancellationToken cancellationToken)
        {
            return await useCase.ExecuteAsync(request, cancellationToken);
        }
    }
}
