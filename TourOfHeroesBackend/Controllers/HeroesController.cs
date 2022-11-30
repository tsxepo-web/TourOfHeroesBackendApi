using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroesDB.Entity;
using HeroesDAL.Interfaces;

namespace TourOfHeroesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _herosRepository;

        public HeroesController(IHeroRepository context)
        {
            _herosRepository = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            return await _herosRepository.Get();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            return await _herosRepository.Get(id);
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero([FromBody] Hero hero)
        {
            var newHero = await _herosRepository.Create(hero);

            return CreatedAtAction(nameof(GetHero), new { id = newHero.Id }, newHero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var heroToDelete = await _herosRepository.Get(id);
            if (heroToDelete == null)
            {
                return NotFound();
            }
            await _herosRepository.Delete(heroToDelete.Id);
            return NoContent();
        }
    }
}
