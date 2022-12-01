using HeroesDAL.Interfaces;
using HeroesDB.Mongodb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HeroesDB.Entity;

namespace HeroesDAL.MongodbServices
{
    public class MongoHeroService: IHeroRepository
    {
        private readonly IMongoCollection<Hero> _heroCollection;
        public MongoHeroService(IOptions<HeroesDatabaseSettings> heroDatabaseSettings) 
        {
            var mongoClient = new MongoClient(heroDatabaseSettings.Value.ConnectionString);
            var MongoDatabase = mongoClient.GetDatabase(heroDatabaseSettings.Value.DatabaseName);

            _heroCollection = MongoDatabase.GetCollection<Hero>(heroDatabaseSettings.Value.HeroCollectionName);
        }
        public async Task<IEnumerable<Hero>> Get() => await _heroCollection.Find(_ => true).ToListAsync();
        public async Task<Hero> Get(int id) => await _heroCollection.Find(x=> x.Id == id).FirstOrDefaultAsync();
        public async Task Create(Hero hero) => await _heroCollection.InsertOneAsync(hero);
        public async Task Update(Hero hero) => await _heroCollection.ReplaceOneAsync(x => x.Id == hero.Id, hero);
        public async Task Delete(int id) => await _heroCollection.DeleteOneAsync(x => x.Id == id);

    }
}
