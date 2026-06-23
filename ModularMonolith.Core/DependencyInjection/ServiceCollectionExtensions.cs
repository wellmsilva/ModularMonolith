using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Core.Events;

namespace ModularMonolith.Core.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModuleCore(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        return services;
    }
}
