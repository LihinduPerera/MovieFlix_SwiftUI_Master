using Microsoft.AspNetCore.Mvc;
using MovieFlix.Api.Services;

namespace MovieFlix.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public UsersController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("{userId:int}/favorites")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await _favoriteService.GetUserFavoritesAsync(userId);

            return Ok(favorites);
        }

        [HttpPost("{userId:int}/favorites/{movieId:int}")]
        public async Task<IActionResult> AddFavorite(int userId, int movieId)
        {
            var favorite = await _favoriteService
                .AddFavoriteAsync(userId, movieId);

            if (favorite is null)
            {
                return NotFound();
            }

            return CreatedAtAction(
                nameof(GetFavorites),
                new { userId },
                favorite);
        }

        [HttpDelete("{userId:int}/favorites/{movieId:int}")]
        public async Task<IActionResult> RemoveFavorite(int userId, int movieId)
        {
            var removed = await _favoriteService.RemoveFavoriteAsync(userId, movieId);

            if(!removed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
