using HeroesDB.Entity;

namespace GameLogic
{
    public class Battle
    {
        public void Logic(Hero hero, WeatherForecast forecast)
        {
            if (forecast.Temp < 0)
            {
                if (hero.Powers == Powers.Fire){ hero.Weatherboost = -25;}
                else if (hero.Powers == Powers.Air){ hero.Weatherboost = 10;}
                else if (hero.Powers == Powers.Earth){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Water){ hero.Weatherboost = 20;}
                else if (hero.Powers == Powers.Ice){ hero.Weatherboost = 25;}
            }

            else if (forecast.Temp > 0 && forecast.Temp < 15)
            {
                if (hero.Powers == Powers.Fire){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Air){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Earth){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Water){ hero.Weatherboost = 10;}
                else if (hero.Powers == Powers.Ice){ hero.Weatherboost = 0;}
            }
            else if (forecast.Temp > 15 && forecast.Temp < 30)
            {
                if (hero.Powers == Powers.Fire){ hero.Weatherboost = 10;}
                else if (hero.Powers == Powers.Air){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Earth){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Water){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Ice){ hero.Weatherboost = -10;}
            }
            else if (forecast.Temp > 30)
            {
                if (hero.Powers == Powers.Fire){ hero.Weatherboost = 25;}
                else if (hero.Powers == Powers.Air){ hero.Weatherboost = 15;}
                else if (hero.Powers == Powers.Earth){ hero.Weatherboost = 0;}
                else if (hero.Powers == Powers.Water){ hero.Weatherboost = -5;}
                else if (hero.Powers == Powers.Ice){ hero.Weatherboost = -25;}
            }

            hero.PowerLevel = hero.Weatherboost;
        }
    }
}