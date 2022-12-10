using HeroesWeatherService.DTO;

namespace HeroesWeatherService.Interface
{
    public interface IWeatherService
    {
        public Task<WeatherResponse> GetWeatherAsync(string location);
    }
}
