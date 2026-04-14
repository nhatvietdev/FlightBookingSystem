using FlightBookingSystem.Domain.Common;

namespace FlightBookingSystem.Domain.Entities.Bookings.Events;

public record BookingCreatedEvent(
    Guid BookingId,
    string FlightCode,
    string PassengerEmail) : DomainEventBase;