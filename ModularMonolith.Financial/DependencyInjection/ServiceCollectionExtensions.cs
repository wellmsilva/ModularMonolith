using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Core.Events;
using ModularMonolith.Financial.Application.EventHandlers;
using ModularMonolith.Financial.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace ModularMonolith.Financial.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Financial module services to the IServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFinancial(this IServiceCollection services)
    {
        services.AddContexts();
        services.AddEventHandlers();

        return services;
    }

    /// <summary>
    /// Applies pending migrations for the Financial module's database context.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseFinancialMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<FinancialDbContext>();
        db.Database.Migrate();

        return app;
    }

    private static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventHandler<ProductCreatedEvent>, ProductCreatedHandler>();

        return services;
    }

    private static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddDbContext<FinancialDbContext>((serviveProvider, options) =>
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
