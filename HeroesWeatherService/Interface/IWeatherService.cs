using HeroesWeatherService.DTO;

namespace HeroesWeatherService.Interface
{
    public interface IWeatherService
    {
        public Task<WeatherForecast> GetWeatherAsync(string location);
    }
}
