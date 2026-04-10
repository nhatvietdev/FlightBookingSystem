namespace FlightBookingSystem.Application.Bookings.Queries.GetBookingById;

public sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingDetailsDto?>
{
    private readonly IBookingRepository _bookingRepository;

    public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<BookingDetailsDto?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(request.BookingId);
        if (booking is null)
        {
            return null;
        }

        return new BookingDetailsDto(
            booking.Id,
            booking.PassengerName,
            booking.FlightCode,
            booking.PassengerEmail,
            booking.Status);
    }
}
