namespace MovieFlix.Api.Exceptions
{
    public class TmdbServiceException : Exception
    {
        public TmdbServiceException()
            : base("The movie provider could not complete the request.")
        {

        }
    }
}
