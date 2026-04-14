using FlightBookingSystem.Domain.Common.Interface;
using MediatR;

namespace FlightBookingSystem.Domain.Events;

public sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IPublisher _publisher;

    public DomainEventDispatcher(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task DispatchAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken)
    {
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish((dynamic)domainEvent, cancellationToken);
        }
    }
}
