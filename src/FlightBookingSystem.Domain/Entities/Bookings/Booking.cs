using FlightBookingSystem.Domain.Common;
using FlightBookingSystem.Domain.Entities.Bookings.Events;

namespace FlightBookingSystem.Domain.Entities.Bookings;

public class Booking : AggregateRoot<Guid>
{
    public string PassengerName { get; private set; }
    public string PassengerEmail { get; private set; }
    public string FlightCode { get; private set; }
    public BookingStatus Status { get; private set; }

    private Booking() { }

    private Booking(string passengerName, string passengerEmail, string flightCode)
    {
        PassengerName = passengerName ?? throw new ArgumentNullException(nameof(passengerName));
        PassengerEmail = passengerEmail ?? throw new ArgumentNullException(nameof(passengerEmail));
        FlightCode = flightCode;
        Status = BookingStatus.Pending;
    }

    public static Booking Create(string passengerName, string passengerEmail, string flightCode)
    {
        var booking = new Booking(passengerName, passengerEmail, flightCode);
        booking.AddDomainEvent(new BookingCreatedEvent(booking.Id, booking.FlightCode, booking.PassengerEmail));
        return booking;
    }

    //public void Confirm()
    //{
    //    if (Status != BookingStatus.Pending)
    //        throw new InvalidOperationException("Only pending booking can be confirmed.");

    //    Status = BookingStatus.Confirmed;

    //    AddDomainEvent(new BookingConfirmedDomain(Id, FlightCode, PassengerEmail));
    //}

    //public void Cancel()
    //{
    //    if (Status == BookingStatus.Cancelled)
    //        return;

    //    Status = BookingStatus.Cancelled;

    //    AddDomainEvent(new BookingCancelledDomain(Id, FlightCode, PassengerEmail));
    //}
}