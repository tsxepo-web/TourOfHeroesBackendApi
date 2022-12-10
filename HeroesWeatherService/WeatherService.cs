using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using HeroesWeatherService.DTO;
using HeroesWeatherService.Interface;

namespace HeroesWeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherService _weatherService;
        readonly string _endpoint;

        public WeatherService(IWeatherService weatherService, string endpoint)
        {
            _weatherService = weatherService;
            _endpoint = endpoint;
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
