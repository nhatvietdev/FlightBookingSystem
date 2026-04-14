namespace FlightBookingSystem.Application.Common.Interface;

public interface IUser
{
    string? Id { get; }
    List<string>? Roles { get; }
}
