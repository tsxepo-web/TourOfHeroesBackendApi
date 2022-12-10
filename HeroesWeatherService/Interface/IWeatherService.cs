using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesWeatherService.DTO;

namespace HeroesWeatherService.Interface
{
    public interface IWeatherService
    {
        public Task<WeatherResponse> GetWeatherAsync(string location);
    }
}
