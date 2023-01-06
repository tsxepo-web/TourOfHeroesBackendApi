using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;


using System.Text.Json;
using System.Threading.Tasks;
using HeroesDB.Entity;
using HeroesWeatherService.Config;
using HeroesWeatherService.DTO;
using HeroesWeatherService.Interface;
using Microsoft.Extensions.Options;

namespace HeroWeatherService
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly OpenWeather _openWeatherConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        public OpenWeatherService(IOptions<OpenWeather> opts, IHttpClientFactory httpFactory)
        {
            _openWeatherConfig = opts.Value ?? throw new ArgumentException(nameof(OpenWeather));    
            _httpClientFactory = httpFactory;
        }
        public async Task<WeatherForecast> GetWeatherAsync(string location)
        {
            //string url =  "https://api.openweathermap.org/data/2.5/weather?q={location}&appid={_openWeatherConfig.ApiKey}&units=metric";
            string url = "https://api.openweathermap.org/data/2.5/weather?q=Durban&appid=aef67a1273785459520a022feafe6021&units=metric";
            var forecasts = new WeatherForecast();
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var openWeatherResponse = JsonSerializer.Deserialize<OpenWeatherResponse>(jsonResponse);
            if (openWeatherResponse != null)
            {
                forecasts.Temp = openWeatherResponse.Main.Temp;
            }
            return forecasts;
        }
    }
}
