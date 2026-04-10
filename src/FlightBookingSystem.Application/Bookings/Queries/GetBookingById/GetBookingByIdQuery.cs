namespace FlightBookingSystem.Application.Bookings.Queries.GetBookingById;

public record GetBookingByIdQuery(Guid BookingId) : IRequest<BookingDetailsDto?>;
