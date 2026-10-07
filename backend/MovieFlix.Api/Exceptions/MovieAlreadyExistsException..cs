namespace MovieFlix.Api.Exceptions
{
    public class MovieAlreadyExistsException : Exception
    {
        public MovieAlreadyExistsException(int tmdbId)
            : base($"A movie with TMDB ID {tmdbId} already exists.")
        {

        }
    }
}
