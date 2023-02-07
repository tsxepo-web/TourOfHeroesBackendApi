using HeroesDB.Entity;

namespace GameLogic
{
    public class Battle
    {
        public Hero Logic(Hero hero, WeatherForecast forecast)
        {
            if (forecast.Temp < 0)
            {
                if (hero.Powers == Powers.Fire) { hero.Weatherboost = -25.0; }
                else if (hero.Powers == Powers.Air) { hero.Weatherboost = 10.0; }
                else if (hero.Powers == Powers.Earth) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Water) { hero.Weatherboost = 20.0; }
                else if (hero.Powers == Powers.Ice) { hero.Weatherboost = 25.0; }
            }

            else if (forecast.Temp > 0 && forecast.Temp < 15)
            {
                if (hero.Powers == Powers.Fire) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Air) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Earth) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Water) { hero.Weatherboost = 10.0; }
                else if (hero.Powers == Powers.Ice) { hero.Weatherboost = 0.0; }
            }
            else if (forecast.Temp > 15 && forecast.Temp < 30)
            {
                if (hero.Powers == Powers.Fire) { hero.Weatherboost = 10.0; }
                else if (hero.Powers == Powers.Air) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Earth) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Water) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Ice) { hero.Weatherboost = -10.0; }
            }
            else if (forecast.Temp > 30)
            {
                if (hero.Powers == Powers.Fire) { hero.Weatherboost = 25.0; }
                else if (hero.Powers == Powers.Air) { hero.Weatherboost = 15.0; }
                else if (hero.Powers == Powers.Earth) { hero.Weatherboost = 0.0; }
                else if (hero.Powers == Powers.Water) { hero.Weatherboost = -5.0; }
                else if (hero.Powers == Powers.Ice) { hero.Weatherboost = -25.0; }
            }

            hero.PowerLevel = hero.Weatherboost;
            return hero;
        }
    }
}