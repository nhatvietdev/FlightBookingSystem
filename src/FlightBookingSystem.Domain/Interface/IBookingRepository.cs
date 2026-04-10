using FlightBookingSystem.Domain.Bookings;

namespace FlightBookingSystem.Domain.Interface;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);
    Task<Booking?> GetByIdAsync(Guid bookingId);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(Guid bookingId);
}
