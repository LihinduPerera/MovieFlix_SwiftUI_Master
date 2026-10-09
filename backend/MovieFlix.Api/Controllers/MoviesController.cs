using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieFlix.Api.DTOs.Movies;
using MovieFlix.Api.DTOs.Tmdb;
using MovieFlix.Api.Services;

namespace MovieFlix.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly ITmdbService _tmdbService;

    public MoviesController(IMovieService movieService, ITmdbService tmdbService)
    {
        _movieService = movieService;
        _tmdbService = tmdbService;
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

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
    {
        var movie = await _movieService.CreateMovieAsync(request);

        return CreatedAtAction(
            nameof(GetMovie),
            new { id = movie.Id },
            movie);
    }

    [Authorize(Roles = "Admin")]
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

    [Authorize(Roles = "Admin")]
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

    [HttpGet("search")]
    public async Task<ActionResult<TmdbMovieSearchResponse>> SearchMovies(
        [FromQuery] string query,
        [FromQuery] int page = 1,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Search query is required.");
        }
        if (query.Trim().Length > 200)
        {
            return BadRequest("Search query cannot exeed 200 characters.");
        }
        if (page < 1 || page > 500)
        {
            return BadRequest("Page must be between 1 and 500.");
        }

        var resutl = await _tmdbService.SearchMoviesAsync(
            query.Trim(),
            page,
            cancellationToken);

        return Ok(resutl);
    }
}