using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using MovieFlix.Api.Configuration;
using MovieFlix.Api.DTOs.Tmdb;
using MovieFlix.Api.Exceptions;

namespace MovieFlix.Api.Services
{
    public class TmdbService : ITmdbService
    {
        private readonly HttpClient _httpClient;

        public TmdbService(HttpClient httpClient, IOptions<TmdbSettings> options)
        {
            _httpClient = httpClient;

            var settings = options.Value;

            _httpClient.BaseAddress = new Uri(settings.BaseUrl);

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", settings.AccessToken);
        }

        public async Task<TmdbMovieSearchResponse> SearchMoviesAsync(
            string query,
            int page,
            CancellationToken cancellationToken = default)
        {
            var encodedQuery = Uri.EscapeDataString(query);

            var url = $"search/movie?query={encodedQuery}&page={page}";

            using var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new TmdbServiceException();
            }

            var result = await response.Content.ReadFromJsonAsync<TmdbMovieSearchResponse>(
                cancellationToken: cancellationToken);

            return result ?? throw new InvalidOperationException("TMDB returned an empty response.");
        }
    }
}
