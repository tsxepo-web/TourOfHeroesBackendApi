using System.Collections.Generic;
using Autofac.Extras.Moq;
using HeroesDAL.Interfaces;
using HeroesDAL.SqlServices;
using HeroesDB.Entity;
using HeroesWeatherService.DTO;
using HeroesWeatherService.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TourOfHeroesBackend.Controllers;
using Xunit;

namespace TourOfHeroesBackendTest
{
    public class UnitTestControlller
    {
        private readonly Mock<IHeroRepository> _heroService;
        private readonly Mock<IWeatherService> _weatherService;
        private readonly HeroesController _controller;

        public UnitTestControlller()
        {
            _heroService = new Mock<IHeroRepository>();
            _weatherService = new Mock<IWeatherService>();
            _controller = new HeroesController(_heroService.Object, _weatherService.Object);
        }
        
        [Fact]
        public void GetoHero_ShouldReturnTrueBoostWhenTempWeatherHeroIsFire()
        {
            List<Hero> heroList = new List<Hero>() {
                new Hero { Id=1, Name="SuperMan", Power="fire"}
            };
            var Hotweather = new WeatherResponse()
            {
                Temperature = 11
            };
            _heroService.Setup(repo => repo.GetHeroesAsync()).ReturnsAsync(heroList);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);

            var hero = _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.True(hero.Value?.Weatherboost, "weather should be true");
        }
        [Fact]
        public async void GetHero_ShouldReturnFalseWhenWeatherLessThanTenHeroIsFire()
        {
            var heroList = new List<Hero>() {
                new Hero { Id=1, Name="SuperMan", Power="fire" }
            };
            var Hotweather = new WeatherResponse()
            {
                Temperature = 10
            };
            _heroService.Setup(repo => repo.GetHeroesAsync()).ReturnsAsync(heroList);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);
            

            var hero =  _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;


            Assert.True(hero.Value?.Weatherboost, "weather should be true");

        }

    }
}