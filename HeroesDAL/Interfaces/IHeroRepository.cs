
//using System.Threading.Tasks;
using HeroesDB.Entity;

namespace HeroesDAL.Interfaces
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> Get();
        Task<Hero> Get(int Id);
        Task<Hero> Create(Hero hero);
        Task Update(Hero hero);
        Task Delete(int Id);
    }
}
