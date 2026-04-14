using FlightBookingSystem.Application.Common.Interface.Repositories;
using FlightBookingSystem.Domain.Entities.Bookings;

namespace FlightBookingSystem.Application.Features.Bookings.Queries.GetBookingById;

public sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingDetailsDto?>
{
    private readonly IGenericRepository<Booking, Guid> _repository;

    public GetBookingByIdQueryHandler(IGenericRepository<Booking, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<BookingDetailsDto?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await _repository.FirstOrDefaultAsync(
            _repository.GetQueryableSet().Where(b => b.Id == request.BookingId));

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
