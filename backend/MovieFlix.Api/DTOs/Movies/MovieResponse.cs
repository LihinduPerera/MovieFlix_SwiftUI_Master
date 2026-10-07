//Response DTOs — Don't Expose Your Database Entities

namespace MovieFlix.Api.DTOs.Movies
{
    public class MovieResponse
    {
        public int Id { get; set; }

        public int TmdbId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Overview { get; set; } = string.Empty;
    }
}
