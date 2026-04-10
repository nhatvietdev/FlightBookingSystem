namespace FlightBookingSystem.Domain.Common;

public class BaseEntity : BaseAuditableEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}
