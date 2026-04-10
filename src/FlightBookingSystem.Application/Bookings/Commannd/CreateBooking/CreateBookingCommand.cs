namespace FlightBookingSystem.Application.Bookings.Commannd.CreateBooking;

public record CreateBookingCommand(
    string PassengerName,
    string FlightCode,
    string PassengerEmail) : IRequest<Guid>;
