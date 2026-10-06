using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetMovies()
    {
        var movies = _movieService.GetMovies();

        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovies(int id)
    {
        var movie = _movieService.GetMovieById(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

}