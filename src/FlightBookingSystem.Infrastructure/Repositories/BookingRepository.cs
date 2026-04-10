using FlightBookingSystem.Domain.Bookings;
using FlightBookingSystem.Domain.Interface;
using FlightBookingSystem.Infrastructure.Persistence;

namespace FlightBookingSystem.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid bookingId)
    {
        var booking = await _context.Bookings.FindAsync(bookingId);
        if (booking is not null)
        {
            _context.Bookings.Remove(booking);
        }
    }

    public async Task<Booking?> GetByIdAsync(Guid bookingId)
    {
        return await _context.Bookings.FindAsync(bookingId);
    }

    public Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        return Task.CompletedTask;
    }
}
