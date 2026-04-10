using FlightBookingSystem.Domain.Events;

namespace FlightBookingSystem.Domain.Interface;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken);
}
