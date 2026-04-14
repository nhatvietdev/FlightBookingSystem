namespace FlightBookingSystem.Domain.Common;

public abstract class BaseAuditableEntity
{
    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
