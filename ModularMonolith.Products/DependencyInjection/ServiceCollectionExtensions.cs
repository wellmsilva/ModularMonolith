using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Core.Abstractions;
using ModularMonolith.Core.Events;
using ModularMonolith.Products.Application.EventHandlers;
using ModularMonolith.Products.Application.UseCases.CreateProduct;
using ModularMonolith.Products.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ModularMonolith.Contracts.Events;
using Microsoft.AspNetCore.Builder;

namespace ModularMonolith.Products.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Products module services to the IServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddProducts(this IServiceCollection services)
    {     
        services.AddContexts();

        services.AddUseCases();
        services.AddEventHandlers();

        return services;
    }

    public static IApplicationBuilder UseProductsMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<ProductsDbContext>();
        db.Database.Migrate();

        return app;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IUseCase<CreateProductRequest, CreateProductResponse>,
           CreateProductUseCase>();

        return services;
    }

    private static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventHandler<ProductCreatedEvent>, ProductCreatedHandler>();

        return services;
    }

    private static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddDbContext<ProductsDbContext>((serviveProvider, options) =>
        {
            var configuration = serviveProvider.GetRequiredService<IConfiguration>();

            options.UseNpgsql(configuration.GetConnectionString("ModularMonolith"),
                b =>
                {
                    b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            options.EnableSensitiveDataLogging();
        }, ServiceLifetime.Scoped, ServiceLifetime.Scoped);

        return services;
    }
}
