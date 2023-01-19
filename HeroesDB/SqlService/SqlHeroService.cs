using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesSqlDb.Entity;
using HeroesSqlDb.Interfaces;
using HeroesSqlDb.SqlDbContext;
using Microsoft.EntityFrameworkCore;

namespace HeroesSqlDb.SqlService
{
        public class SqlHeroService : IHeroRepository
        {
            private readonly HeroContext _context;
            public SqlHeroService(HeroContext context)
            {
                _context = context;
            }
            public async Task CreateHeroAsync(Hero hero)
            {
                _context.Heroes.Add(hero);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteHeroAsync(int Id)
            {
                var heroToDelete = await _context.Heroes.FindAsync(Id);
                if (heroToDelete is null)
                {
                    return;
                }
                _context.Heroes.Remove(heroToDelete);
                await _context.SaveChangesAsync();
            }

            public async Task<IEnumerable<Hero>> GetHeroesAsync()
            {
                return await _context.Heroes.ToListAsync();
            }

            public async Task<Hero?> GetHeroAsync(int Id, string location)
            {
                return await _context.Heroes.FindAsync(Id);
            }

            public async Task UpdateHeroAsync(Hero hero)
            {
                _context.Entry(hero).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
}
