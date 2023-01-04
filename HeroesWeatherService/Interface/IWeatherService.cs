using HeroesDB.Entity;

namespace HeroesWeatherService.Interface
{
    public enum Unit
    {
        Metric,
        Imperial,
        Kelvin
    }

    public interface IWeatherService
    {
        public Task<List<WeatherForecast>> GetWeatherAsync(string location, Unit unit = Unit.Metric);
    }
}
