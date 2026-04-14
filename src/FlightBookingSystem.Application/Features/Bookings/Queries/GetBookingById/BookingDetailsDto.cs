using FlightBookingSystem.Domain.Entities.Bookings;

namespace FlightBookingSystem.Application.Features.Bookings.Queries.GetBookingById;

public sealed record BookingDetailsDto(
    Guid Id,
    string PassengerName,
    string FlightCode,
    string PassengerEmail,
    BookingStatus Status);
