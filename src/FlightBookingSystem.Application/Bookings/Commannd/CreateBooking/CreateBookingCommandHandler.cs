using FlightBookingSystem.Domain.Bookings;

namespace FlightBookingSystem.Application.Bookings.Commannd.CreateBooking;

public sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingCommandHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = Booking.Create(request.PassengerName, request.PassengerEmail, request.FlightCode);
        await _bookingRepository.AddAsync(booking);
        await _unitOfWork.CommitAsync(cancellationToken);
        return booking.Id;
    }
}
