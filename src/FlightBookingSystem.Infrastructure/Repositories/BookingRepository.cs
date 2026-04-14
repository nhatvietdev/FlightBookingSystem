using FlightBookingSystem.Domain.Entities.Bookings;
using FlightBookingSystem.Infrastructure.Persistence;

namespace FlightBookingSystem.Infrastructure.Repositories;

public class BookingRepository : GenericRepository<Booking, Guid>
{

    public BookingRepository(ApplicationDbContext context) : base(context)
    {

    }
}
