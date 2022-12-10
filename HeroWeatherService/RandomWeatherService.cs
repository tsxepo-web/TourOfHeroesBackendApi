using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesWeatherService.DTO;
using HeroesWeatherService.Interface;
//using HeroesWeatherService.DTO;

namespace HeroesWeatherService
{
    public class RandomWeatherService: IWeatherService
    {
        private readonly Random random = new();

        public Task<WeatherResponse> GetWeatherAsync(string location)
        {
            return Task.FromResult(GetRandomWeather());
        }

        private WeatherResponse GetRandomWeather()
        {
            var response = new WeatherResponse()
            {
                Temperature = random.Next(100),
                Humidity = random.NextDouble(),
                Pressure = random.NextDouble(),
            };
            return response;
        }
    }
}
