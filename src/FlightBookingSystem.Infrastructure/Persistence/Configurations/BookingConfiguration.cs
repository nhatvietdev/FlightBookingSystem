using FlightBookingSystem.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightBookingSystem.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.PassengerName).IsRequired().HasMaxLength(200);
        builder.Property(b => b.FlightCode).IsRequired().HasMaxLength(10);
        builder.Property(b => b.PassengerEmail).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Status).HasConversion<int>();
    }
}
