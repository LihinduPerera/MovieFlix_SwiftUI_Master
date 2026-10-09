using System.Text.Json.Serialization;

namespace MovieFlix.Api.DTOs.Tmdb
{
    public class TmdbMovieSearchResponse
    {
        public int Page { get; set; }

        public List<TmdbMovieResult> Results { get; set; } = [];

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
