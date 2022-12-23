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
        public void GetoHero_ShouldReturnTrueBoostWhenTempWeatherHeroPowerIsFire()
        {
            var hero = new Hero { Id=1, Name="SuperMan", Power="fire" };
            var Hotweather = new WeatherResponse() {Temperature = 11};
            _heroService.Setup(repo => repo.GetHeroAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(hero);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);

            var response = _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.True(response.Value?.Weatherboost, "weather should be true");
        }
        [Fact]
        public void GetHero_ShouldReturnTrueWhenWeatherEqualsTenAndHeroPowerIsFire()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "fire" };
            var Hotweather = new WeatherResponse() { Temperature = 10 };
            _heroService.Setup(repo => repo.GetHeroAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(hero);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);
            
            var response =  _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.True(response.Value?.Weatherboost, "weather should be true");
        }
        [Fact]
        public void GetHero_ShouldReturnFalseWhenWeatherGreaterOrEqualsTenAndHeroPowerIsCold()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "cold" };
            var Hotweather = new WeatherResponse() { Temperature = 11 };
            _heroService.Setup(repo => repo.GetHeroAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(hero);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);

            var response = _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.False(response.Value?.Weatherboost, "weather should be false");
        }
        [Fact]
        public void GetHero_ShouldReturnTrueWhenWeatherLessThanTenAndHeroPowerIsCold()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "cold" };
            var Hotweather = new WeatherResponse() { Temperature = 9 };
            _heroService.Setup(repo => repo.GetHeroAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(hero);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);

            var response = _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.True(response.Value?.Weatherboost, "weather should be true");
        }
        [Fact]
        public void GetHero_ShouldReturnFalseWhenWeatherLessThanTenAndHeroPowerIsFire()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "fire" };
            var Hotweather = new WeatherResponse() { Temperature = 9 };
            _heroService.Setup(repo => repo.GetHeroAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(hero);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>())).ReturnsAsync(Hotweather);

            var response = _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.False(response.Value?.Weatherboost, "weather should be false");
        }
        [Fact]
        public void GetHero_ShouldReturnNullWhenHeroIsEmpty()
        {
            var hero = new Hero { };
            var Hotweather = new WeatherResponse() { Temperature = 10 };
            _heroService.Setup(repo => repo.GetHeroAsync(It.IsAny<int>(), It.IsAny<string>()))
                        .ReturnsAsync(hero);
            _weatherService.Setup(repo => repo.GetWeatherAsync(It.IsAny<string>()))
                           .ReturnsAsync(Hotweather);

            var response = _controller.GetHero(It.IsAny<int>(), It.IsAny<string>()).Result;

            Assert.Null(response.Value?.Name);
        }
        [Fact]
        public void DeleteHero_ShouldBreakIfHeroToDeleteIsNull()
        {
            var heroToDelete = new Hero { };
            var heroId = 2;
            _heroService.Setup(x => x.GetHeroAsync(heroId, It.IsAny<string>()))
                        .ReturnsAsync(heroToDelete);
            _heroService.Setup(x => x.DeleteHeroAsync(heroToDelete.Id))
                        .Returns(Task.CompletedTask);
            
            var response = _controller.DeleteHero(heroId, It.IsAny<string>());

            _heroService.Verify(x => x.DeleteHeroAsync(heroId), Times.Never());
        }
        [Fact]
        public void DeleteHero_ShouldVerifyDeleteHeroAsyncMethodIsCalledOnce()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "fire" };
            _heroService.Setup(x => x.GetHeroAsync(hero.Id, It.IsAny<string>()))
                        .ReturnsAsync(hero);
            _heroService.Setup(x => x.DeleteHeroAsync(hero.Id))
                        .Returns(Task.CompletedTask);

            var response = _controller.DeleteHero(hero.Id, It.IsAny<string>());

            _heroService.Verify(x => x.DeleteHeroAsync(hero.Id), Times.Once());
        }
        [Fact]
        public void PutHero_ShouldBreakIfHeroIdIsNotFound()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "fire" };
            _heroService.Setup(x => x.UpdateHeroAsync(hero))
                        .Returns(Task.CompletedTask);

            var response = _controller.PutHero(999, hero);

            _heroService.Verify(x => x.UpdateHeroAsync(hero), Times.Never());
        }
        [Fact]
        public void PutHero_ShouldVerifyIfUpdateHeroAsyncMethodIsCalledOnce()
        {
            var hero = new Hero { Id = 1, Name = "SuperMan", Power = "fire" };
            _heroService.Setup(x => x.UpdateHeroAsync(hero))
                        .Returns(Task.CompletedTask);

            var response = _controller.PutHero(hero.Id, hero);

            _heroService.Verify(x => x.UpdateHeroAsync(hero), Times.Once());
        }
    }
}