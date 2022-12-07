using HeroesDB.Entity;
using Newtonsoft.Json;

namespace HeroesDB.OpenWeatherMap
{
    public class OpenWeatherMapSettings
    {
        public async Task WeatherDetail(string City)
        {
            string appId = "aef67a1273785459520a022feafe6021";
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&appid={1}", City, appId);
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic? weatherInfo = JsonConvert.DeserializeObject(responseBody);
        }
    }
}
