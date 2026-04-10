using FlightBookingSystem.Domain.Bookings;

namespace FlightBookingSystem.Application.Bookings.Queries.GetBookingById;

public sealed record BookingDetailsDto(
    Guid Id,
    string PassengerName,
    string FlightCode,
    string PassengerEmail,
    BookingStatus Status);
