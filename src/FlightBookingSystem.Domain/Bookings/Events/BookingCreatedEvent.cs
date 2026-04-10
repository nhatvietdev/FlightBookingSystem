using FlightBookingSystem.Domain.Events;

namespace FlightBookingSystem.Domain.Bookings.Events;

public record BookingCreatedEvent(
    Guid BookingId, 
    string FlightCode, 
    string PassengerEmail) : DomainEventBase;