using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace FlightBookingSystem.Api.ExceptionHandlers;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                title = "Validation failed",
                errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            },
            cancellationToken);
        return true;
    }
}
