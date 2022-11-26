using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroDB.Entity;

namespace HeroDAL.Interface
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
