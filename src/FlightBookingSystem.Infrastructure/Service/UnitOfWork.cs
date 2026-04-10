using FlightBookingSystem.Domain.Interface;
using FlightBookingSystem.Infrastructure.Persistence;

namespace FlightBookingSystem.Infrastructure.Service;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}