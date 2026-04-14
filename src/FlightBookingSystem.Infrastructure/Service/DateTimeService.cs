using FlightBookingSystem.Application.Common.Interface;

namespace FlightBookingSystem.Infrastructure.Service;

public class DateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}
