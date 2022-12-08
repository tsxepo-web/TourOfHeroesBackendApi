using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDAL.Interfaces;
using HeroesDB.Entity;
using HeroesDB.OpenWeatherMap;
using Microsoft.EntityFrameworkCore;
using HeroesDB.Sqldb;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace HeroesDAL.SqlServices
{
    public class SqlHeroService : IHeroRepository
    {
        private readonly HeroContext _context;
        private readonly HttpClient _client;
        private readonly string? apiKey;

        public SqlHeroService(HeroContext context, IConfiguration configuration)
        {
            _context = context;
            _client = new();
            apiKey = configuration["OpenWeatherMapSettings: OpenWeatherMapApiKey"];
        }
        public async Task Create(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        { 
            var heroToDelete = await _context.Heroes.FindAsync(Id);
            _context.Heroes.Remove(heroToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hero>> Get()
        {
            return await _context.Heroes.ToListAsync();
        }

        public async Task<Hero> Get(int Id, string location)
        {
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&appid={1}", location, appId);

            return await _context.Heroes.FindAsync(Id);
        }

        public async Task Update(Hero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ResultViewModel>?> GetLocations(RootObject rootObject)
        {
            string requestUri = GetRequestUri(rootObject);
            HttpResponseMessage response = await _client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            ResultViewModel resultViewModel = await response.Content.ReadAsStringAsync();
            return resultViewModel;
        }

        public string GetRequestUri(RootObject rootObject) => $"https://openweathermap.org/data/2.5/q={RootObject.City}&limit=5&appid={apiKey}";
        {
        }
    }
}
