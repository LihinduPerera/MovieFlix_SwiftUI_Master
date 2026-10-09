namespace MovieFlix.Api.Exceptions
{
    public class TmdbServiceException : Exception
    {
        public TmdbServiceException()
            : base("The movie provider could not complete the request.")
        {

        }

        public TmdbServiceException(Exception innerException)
            :base("The movie provider could not complete the request.", innerException)
        {

        }
    }
}
