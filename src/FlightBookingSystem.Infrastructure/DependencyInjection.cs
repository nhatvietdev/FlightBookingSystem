using FlightBookingSystem.Application.Common.Interface;
using FlightBookingSystem.Application.Common.Interface.Repositories;
using FlightBookingSystem.Domain.Common.Interface;
using FlightBookingSystem.Domain.Events;
using FlightBookingSystem.Infrastructure.Persistence;
using FlightBookingSystem.Infrastructure.Persistence.Interceptors;
using FlightBookingSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSQL")
            ?? configuration.GetConnectionString("Postgress");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

            options.AddInterceptors(
                sp.GetRequiredService<AuditableEntityInterceptor>(),
                sp.GetRequiredService<DispatchDomainEventsInterceptor>());

        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        services.AddScoped<DispatchDomainEventsInterceptor>();
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddTransient<IDateTimeService, IDateTimeService>();

        return services;
    }
}
