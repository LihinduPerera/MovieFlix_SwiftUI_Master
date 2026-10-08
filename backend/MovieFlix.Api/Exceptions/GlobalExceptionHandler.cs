using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MovieFlix.Api.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred.",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "An unexpected error occurred."
        };

        if (exception is MovieAlreadyExistsException movieException)
        {
            problemDetails = new ProblemDetails
            {
                Title = "Movie already exists.",
                Status = StatusCodes.Status409Conflict,
                Detail = movieException.Message
            };
        } 
        else if (exception is FavoriteAlreadyExistsException favoriteException)
        {
            problemDetails = new ProblemDetails
            {
                Title = "Favorite already exists.",
                Status = StatusCodes.Status409Conflict,
                Detail = favoriteException.Message
            };
        }

        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await httpContext.Response.WriteAsJsonAsync(
            problemDetails,
            cancellationToken);

        return true;
    }
}