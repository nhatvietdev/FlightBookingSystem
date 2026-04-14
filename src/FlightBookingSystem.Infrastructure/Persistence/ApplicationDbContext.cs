using FlightBookingSystem.Domain.Common.Interface;
using FlightBookingSystem.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlightBookingSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IDomainEventDispatcher domainEventDispatcher) : base(options)
    {
        _domainEventDispatcher = domainEventDispatcher;
    }

    public DbSet<Booking> Bookings { get; set; }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAggregateRoot)
            .SelectMany(e => ((IAggregateRoot)e.Entity).DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        if (domainEvents.Count > 0)
        {
            await _domainEventDispatcher.DispatchAsync(domainEvents, cancellationToken);
            ClearDomainEvents();
        }

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.HasDefaultSchema("public");
    }

    private void ClearDomainEvents()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is IAggregateRoot aggregate)
            {
                aggregate.ClearDomainEvents();
            }
        }
    }
}
