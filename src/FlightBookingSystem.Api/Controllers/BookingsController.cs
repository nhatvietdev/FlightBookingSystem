using FlightBookingSystem.Application.Features.Bookings.Commannd.CreateBooking;
using FlightBookingSystem.Application.Features.Bookings.Queries.GetBookingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var booking = await _mediator.Send(new GetBookingByIdQuery(id), cancellationToken);
        return booking is null ? NotFound() : Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        var bookingId = await _mediator.Send(command, cancellationToken);
        return Ok(new { bookingId });
    }
}
