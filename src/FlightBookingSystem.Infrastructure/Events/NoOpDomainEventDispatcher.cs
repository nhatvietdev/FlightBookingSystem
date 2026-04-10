using FlightBookingSystem.Domain.Events;
using FlightBookingSystem.Domain.Interface;

namespace FlightBookingSystem.Infrastructure.Events;

/// <summary>
/// Dùng cho design-time (dotnet ef) khi không có container đầy đủ.
/// </summary>
public sealed class NoOpDomainEventDispatcher : IDomainEventDispatcher
{
    public Task DispatchAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
