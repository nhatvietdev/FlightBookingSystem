using MediatR;

namespace FlightBookingSystem.Domain.Common.Interface;

public interface IDomainEvent : INotification
{
    Guid EventId { get; }
    DateTime OccurredOn { get; }
}