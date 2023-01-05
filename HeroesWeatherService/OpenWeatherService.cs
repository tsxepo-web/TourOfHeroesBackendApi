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
        public OpenWeatherService(IOptions<OpenWeather> opts,IHttpClientFactory httpFactory)
        {
            _openWeatherConfig = opts.Value;    
            _httpClientFactory = httpFactory;
        }
        public async Task<WeatherForecast> GetWeatherAsync(string location)
        {
            string url =  "https://api.openweathermap.org/data/2.5/weather?q={location}&appId={_openWeatherConfig.ApiKey}&units =metric";
            var forecasts = new WeatherForecast();
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            var openWeatherResponse = JsonSerializer.Deserialize<OpenWeatherResponse>(contentStream);
            foreach (var forecast in openWeatherResponse.Forecasts)
            {
                forecasts = (new WeatherForecast
                {
                    Date = new DateTime(forecast.Dt),
                    Temp = forecast.Temps.Temp,
                    FeelsLike = forecast.Temps.FeelsLike,
                    TempMin = forecast.Temps.TempMin,
                    TempMax = forecast.Temps.TempMax,
                });
            }
            return forecasts;
        }
        
    }
}
