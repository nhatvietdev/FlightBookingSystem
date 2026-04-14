using FlightBookingSystem.Domain.Events;

namespace FlightBookingSystem.Domain.Entities.Bookings.Events;

public record BookingCreatedEvent(
    Guid BookingId,
    string FlightCode,
    string PassengerEmail) : DomainEventBase;