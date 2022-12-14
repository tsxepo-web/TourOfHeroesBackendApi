using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDAL.Interfaces;
using HeroesDB.Entity;
using Microsoft.EntityFrameworkCore;
using HeroesDB.Sqldb;

namespace HeroesDAL.SqlServices
{
    public class SqlHeroService : IHeroRepository
    {

        private readonly HeroContext _context;
        public SqlHeroService(HeroContext context)
        {
            _context = context;
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

        public async Task<Hero> Get(int Id)
        {
            return await _context.Heroes.FindAsync(Id);
        }

        public async Task Update(Hero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
