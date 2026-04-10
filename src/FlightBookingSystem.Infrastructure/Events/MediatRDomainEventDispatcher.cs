using FlightBookingSystem.Domain.Events;
using FlightBookingSystem.Domain.Interface;
using MediatR;

namespace FlightBookingSystem.Infrastructure.Events;

public sealed class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IPublisher _publisher;

    public MediatRDomainEventDispatcher(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task DispatchAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken)
    {
        foreach (var domainEvent in domainEvents)
        {
            // Publish theo kiểu runtime để MediatR resolve đúng INotificationHandler<TConcrete>
            await _publisher.Publish((dynamic)domainEvent, cancellationToken);
        }
    }
}
