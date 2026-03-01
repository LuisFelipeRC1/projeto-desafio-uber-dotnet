using HttpClientFactory = System.Net.Http.IHttpClientFactory;
using System;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;

namespace Application.Service
{
    public class MovieLocationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "MovieLocations";

        public MovieLocationService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }

        public async Task<IEnumerable<MovieLocationRequest>> GetMovieLocationsAsync()
        {
            if (_cache.TryGetValue(CacheKey, out List<MovieLocationRequest>? cached))
            {
                return cached!;
            }

            var client = _httpClientFactory.CreateClient("MovieLocationMap");
            var response = await client.GetAsync("");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var movieLocations = JsonSerializer.Deserialize<List<MovieLocationRequest>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var result = movieLocations ?? new List<MovieLocationRequest>();
            _cache.Set(CacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task<IEnumerable<MovieLocationRequest>> GetMovieLocationsByMovieName(string movieName)
        {
            var allLocations = await GetMovieLocationsAsync();
            return allLocations.Where(loc => !string.IsNullOrEmpty(loc.title) &&
                   loc.title!.Equals(movieName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<MovieLocationRequest>> GetMovieLocationsByYear(int year)
        {
            var allLocations = await GetMovieLocationsAsync();
            return allLocations.Where(loc => loc.release_year == year);
        }
    }
}