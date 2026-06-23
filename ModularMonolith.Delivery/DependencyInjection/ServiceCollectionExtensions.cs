using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Core.Abstractions;
using ModularMonolith.Delivery.Application.UseCases.CreateDelivery;
using ModularMonolith.Delivery.Persistence;
using System.Reflection;

namespace ModularMonolith.Delivery.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Delivery module services to the IServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDelivery(this IServiceCollection services)
    {
        services.AddContexts();
        services.AddUseCases();

        return services;
    }

 
    public static IApplicationBuilder UseDeliveryMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<DeliveryDbContext>();
        db.Database.Migrate();

        return app;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IUseCase<CreateDeliveryRequest, CreateDeliveryResponse>,
           CreateDeliveryUseCase>();

        return services;
    }

    private static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddDbContext<DeliveryDbContext>((serviveProvider, options) =>
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
