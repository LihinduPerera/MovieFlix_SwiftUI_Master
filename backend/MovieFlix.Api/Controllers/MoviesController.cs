using Microsoft.AspNetCore.Mvc;
using MovieFlix.Api.Models;

namespace MovieFlix.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly List<Movie> _movies =
        [
        new Movie
        {
            Id = 1,
            Title = "Interstellar",
            Overview = "A team of explorers travels through a wormhole in space."
        },
        new Movie
        {
            Id = 2,
            Title = "Inception",
            Overview = "A skilled thief enters people's dreams to steal information."
        },
        new Movie
        {
            Id = 3,
            Title = "The Dark Knight",
            Overview = "Batman faces a dangerous criminal who brings chaos to Gotham."
        }
    ];

    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(_movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovies(int id)
    {
        var movie = _movies.FirstOrDefault(movie => movie.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

}