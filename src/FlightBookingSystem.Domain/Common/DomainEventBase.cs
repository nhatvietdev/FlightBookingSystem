using FlightBookingSystem.Domain.Common.Interface;

namespace FlightBookingSystem.Domain.Common;

public abstract record DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;

    public Guid EventId { get; } = Guid.NewGuid();
}
