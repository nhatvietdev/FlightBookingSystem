namespace FlightBookingSystem.Domain.Events;

public abstract record DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;

    public Guid EventId { get; } = Guid.NewGuid();
}
