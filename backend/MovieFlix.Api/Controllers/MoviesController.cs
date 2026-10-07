using Microsoft.AspNetCore.Mvc;
using MovieFlix.Api.DTOs.Movies;
using MovieFlix.Api.Services;

namespace MovieFlix.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] MovieQueyRequest request)
    {
        if(request.Page < 1)
        {
            return BadRequest("Page must be greater than 0.");
        }

        if(request.PageSize < 1 || request.PageSize > 100)
        {
            return BadRequest("Page size must be between 1 and 100.");
        }

        var movies = await _movieService.GetMoviesAsync(request);

        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMovie(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
    {
        var movie = await _movieService.CreateMovieAsync(request);

        return CreatedAtAction(
            nameof(GetMovie),
            new { id = movie.Id },
            movie);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMovie(int id, UpdateMovieRequest request)
    {
        var movie = await _movieService.UpdateMovieAsync(id, request);

        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var deleted = await _movieService.DeleteMovieAsync(id);

        if(!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}