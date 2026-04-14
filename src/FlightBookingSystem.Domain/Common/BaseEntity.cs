using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Domain.Common;

public abstract class BaseEntity<TKey> : BaseAuditableEntity, IHasKey<TKey>, ITrackable
{
    public TKey Id { get; set; } = default!;

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}

public interface IHasKey<TKey>
{
    TKey Id { get; set; }
}

public interface ITrackable
{
    byte[]? RowVersion { get; set; }
}