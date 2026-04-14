using FluentValidation;

namespace FlightBookingSystem.Application.Features.Bookings.Commannd.CreateBooking;

public sealed class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(x => x.PassengerName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.FlightCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.PassengerEmail)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);
    }
}
