using FlightBookingSystem.Application.Common.Interface.Repositories;
using FlightBookingSystem.Domain.Entities.Bookings;

namespace FlightBookingSystem.Application.Features.Bookings.Commannd.CreateBooking;

public sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IGenericRepository<Booking, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingCommandHandler(IGenericRepository<Booking, Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        var booking = Booking.Create(request.PassengerName, request.PassengerEmail, request.FlightCode);
        await _repository.AddAsync(booking);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return booking.Id;
    }
}
