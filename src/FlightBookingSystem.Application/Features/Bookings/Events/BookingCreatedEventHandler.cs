using FlightBookingSystem.Domain.Entities.Bookings.Events;
using Microsoft.Extensions.Logging;

namespace FlightBookingSystem.Application.Features.Bookings.Events;

public sealed class BookingCreatedEventHandler : INotificationHandler<BookingCreatedEvent>
{
    private readonly ILogger<BookingCreatedEventHandler> _logger;

    public BookingCreatedEventHandler(ILogger<BookingCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BookingCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "BookingCreated: BookingId={BookingId}, FlightCode={FlightCode}, Email={Email}",
            notification.BookingId,
            notification.FlightCode,
            notification.PassengerEmail);
        return Task.CompletedTask;
    }
}
