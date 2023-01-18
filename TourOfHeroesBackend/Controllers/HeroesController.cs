﻿using Microsoft.AspNetCore.Mvc;
using HeroesWeatherService.Interface;
using HeroesSqlDb.Interfaces;
using HeroesSqlDb.Entity;

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
            return await _herosRepository.GetHeroesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero?>> GetHero(int id, string location)
        {
            var hero = await _herosRepository.GetHeroAsync(id, location);
            if (hero == null) { return NotFound(); }
            var forecast = await _weatherService.GetWeatherAsync(location);
            if (forecast.Temp >= 10 && hero.Power == "fire")
            {
                hero.Weatherboost = true;
            }
            else if (forecast.Temp < 10 && hero.Power == "fire")
            {
                hero.Weatherboost = false;
            }
            else if (forecast.Temp >= 10 && hero.Power == "cold")
            {
                hero.Weatherboost = false;
            }
            else if (forecast.Temp < 10 && hero.Power == "cold")
            {
                hero.Weatherboost = true;
            }

            return await _herosRepository.GetHeroAsync(id, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id,[FromBody] Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }
            await _herosRepository.UpdateHeroAsync(hero);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostHero(Hero hero)
        {
            await _herosRepository.CreateHeroAsync(hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id, string location)
        {
            var heroToDelete = await _herosRepository.GetHeroAsync(id, location);
            if (heroToDelete == null)
            {
                return NotFound();
            }
            await _herosRepository.DeleteHeroAsync(heroToDelete.Id);
            return NoContent();
        }
    }
}