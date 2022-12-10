using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using HeroesWeatherService.DTO;
using HeroesWeatherService.Interface;

namespace HeroWeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly string _endpoint;
        private readonly string _apiKey;

        public WeatherService(string weatherApiEndpoint, string apiKey)
        {
            _apiKey = apiKey;
            _endpoint = weatherApiEndpoint;
        }
        public async Task<WeatherResponse> GetWeatherAsync(string location)
        {
            using HttpClient client = new();
            var response = await client.GetAsync(_endpoint);
            var weatherDetails = await response.Content.ReadFromJsonAsync<WeatherResponse>();
            return weatherDetails;
        }
    }
}
