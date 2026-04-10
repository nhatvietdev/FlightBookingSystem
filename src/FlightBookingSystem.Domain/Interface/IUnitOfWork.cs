namespace FlightBookingSystem.Domain.Interface;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
