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
using Newtonsoft.Json;

namespace HeroWeatherService
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly OpenWeather _openWeatherConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        public OpenWeatherService(IOptionsSnapshot<OpenWeather> opts, IHttpClientFactory httpFactory)
        {
            _openWeatherConfig = opts.Value;
            _httpClientFactory = httpFactory;
        }
        public async Task<WeatherForecast> GetWeatherAsync(string location)
        {
            //string url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={_openWeatherConfig.ApiKey}&units=metric";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid=aef67a1273785459520a022feafe6021&units=metric";
            var forecasts = new WeatherForecast();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var openWeatherResponse = JsonConvert.DeserializeObject<OpenWeatherResponse>(jsonResponse);
            if (openWeatherResponse != null)
            {
                forecasts.Temp = openWeatherResponse.main.temp;
            }
            return forecasts;
        }
    }
}
