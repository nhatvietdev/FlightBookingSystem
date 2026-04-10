namespace FlightBookingSystem.Domain.Common;

public class BaseAuditableEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedBy { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
