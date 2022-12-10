using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroesDB.Entity;
using HeroesDAL.Interfaces;
using HeroesDAL.MongodbServices;
using HeroesDAL.SqlServices;
using HeroesWeatherService.Interface;

namespace TourOfHeroesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _herosRepository;
        private readonly IWeatherService _weatherService;

        public HeroesController(IHeroRepository context, IWeatherService weatherService)
        {
            _weatherService = weatherService;   
            _herosRepository = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            return await _herosRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id, string location)
        {
            var weather = await _weatherService.GetWeatherAsync(location);
            var hero = await _herosRepository.Get(id, location);

            if (weather.Temperature >  10 && hero.Power == "fire") 
            {
                hero.Weatherboost = true;
            }
            else if (weather.Temperature > 10 && hero.Power == "cold")
            {
                hero.Weatherboost = false;
            }
            else if (weather.Temperature < 10 && hero.Power == "cold")
            {
                hero.Weatherboost = true;
            }
            else if (weather.Temperature < 10 && hero.Power == "fire")
            {
                hero.Weatherboost = false;
            }
            if (hero == null) {return NotFound();}
            return await _herosRepository.Get(id, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id,[FromBody] Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }
            await _herosRepository.Update(hero);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostHero(Hero hero)
        {
            await _herosRepository.Create(hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id, string location)
        {
            var heroToDelete = await _herosRepository.Get(id, location);
            if (heroToDelete == null)
            {
                return NotFound();
            }
            await _herosRepository.Delete(heroToDelete.Id);
            return NoContent();
        }
    }
}