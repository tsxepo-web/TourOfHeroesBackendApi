using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesWeatherService.DTO;
using HeroesWeatherService.Interface;

namespace HeroesWeatherService
{
    public class RandomWeatherService: IWeatherService
    {
        private readonly Random random = new Random();
        public Task<WeatherResponse> GetWeatherAsync(string location)
        {
            return Task.FromResult(GetRandomWeather());
        }
        public WeatherResponse GetRandomWeather()
        {
            var response = new WeatherResponse()
            {
                Temperature = random.Next(100),
                Pressure = random.NextDouble() * 60,
                Humidity = random.NextDouble() * 60,
            };
            return response;
        }
    }
}
