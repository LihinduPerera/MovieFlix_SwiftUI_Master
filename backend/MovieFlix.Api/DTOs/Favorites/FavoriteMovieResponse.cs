namespace MovieFlix.Api.DTOs.Favorites
{
    public class FavoriteMovieResponse
    {
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public DateTime FavoritedAt { get; set; }
    }
}
