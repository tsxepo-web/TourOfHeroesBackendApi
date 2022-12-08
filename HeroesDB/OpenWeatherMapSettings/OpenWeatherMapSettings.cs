using HeroesDB.Entity;
using Newtonsoft.Json;

namespace HeroesDB.OpenWeatherMap
{
    public class OpenWeatherMapSettings
    {
        public string? OpenWeatherMapApiKey { get; set; }
        public string? BaseUrl { get; set; }
    }
}
