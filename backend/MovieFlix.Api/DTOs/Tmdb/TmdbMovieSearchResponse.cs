namespace MovieFlix.Api.DTOs.Tmdb
{
    public class TmdbMovieSearchResponse
    {
        public int Page { get; set; }

        public List<TmdbMovieResult> Results { get; set; } = [];

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }
    }
}
