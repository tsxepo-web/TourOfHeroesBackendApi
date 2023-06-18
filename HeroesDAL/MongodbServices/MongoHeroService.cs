using HeroesDAL.Interfaces;
using MongoDB.Driver;
using HeroesDB.Entity;

namespace HeroesDAL.MongodbServices
{
    public class MongoHeroService : IHeroRepository
    {
        private readonly IMongoCollection<Hero> _heroCollection;
        public MongoHeroService(IMongoCollection<Hero> heroDatabaseSettings)
        {
            _heroCollection = heroDatabaseSettings;
        }
        public async Task<IEnumerable<Hero>> GetHeroesAsync() => await _heroCollection.Find(_ => true).ToListAsync();
        public async Task<Hero?> GetHeroAsync(int id, string location) => await _heroCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateHeroAsync(Hero hero) => await _heroCollection.InsertOneAsync(hero);
        public async Task UpdateHeroAsync(Hero hero) => await _heroCollection.ReplaceOneAsync(x => x.Id == hero.Id, hero);
        public async Task DeleteHeroAsync(int id) => await _heroCollection.DeleteOneAsync(x => x.Id == id);
    }
}
