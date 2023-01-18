using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeroesDB.Entity;

namespace HeroesSqlDb.Interfaces
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetHeroesAsync();
        Task<Hero?> GetHeroAsync(int Id, string location);
        Task CreateHeroAsync(Hero hero);
        Task UpdateHeroAsync(Hero hero);
        Task DeleteHeroAsync(int Id);
    }
}
