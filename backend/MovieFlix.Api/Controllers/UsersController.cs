using Microsoft.AspNetCore.Mvc;
using MovieFlix.Api.Services;

namespace MovieFlix.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public UsersController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{userId:int}/favorites")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await _movieService.GetUserFavoritesAsync(userId);

            return Ok(favorites);
        }
    }
}
