using HeroesDB.Entity;

namespace HeroesWeatherService.Interface
{
    public interface IWeatherService
    {
        public Task<WeatherForecast> GetWeatherAsync(string location);
    }
}
