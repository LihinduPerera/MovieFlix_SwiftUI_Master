namespace MovieFlix.Api.DTOs.Movies
{
    public class CreateMovieRequest
    {
        public int TmdId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
    }
}
