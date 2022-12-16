using HeroesDAL.Interfaces;
using HeroesDAL.SqlServices;
using HeroesDB.Entity;
using HeroesDB.Sqldb;
using HeroesWeatherService;
using HeroesWeatherService.Interface;
using Moq;

namespace TourOfHeroesBackEnd.Test
{
    public class HeroServiceTest
    {
        private readonly SqlHeroService _sut;
        private readonly Mock<IHeroRepository> _heroRepoMock = new Mock<IHeroRepository>();
        private readonly Mock<IWeatherService> _weatherServiceMock = new Mock<IWeatherService>();   
        public HeroServiceTest()
        {
            _sut = new SqlHeroService(_heroRepoMock.Object);
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_ShouldReturnListOfHeroes()
        {
            //arrange

            //act=00
            var hero = await _sut.Get();
            //assert
            Assert.Equals("x", result);
        }
    }
}