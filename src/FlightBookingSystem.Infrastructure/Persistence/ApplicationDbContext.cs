using FlightBookingSystem.Domain.Common.Interface;
using FlightBookingSystem.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlightBookingSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.HasDefaultSchema("public");
    }
}
