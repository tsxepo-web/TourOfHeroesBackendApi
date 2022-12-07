﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDB.Entity
{
    public class ResultViewModel
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
        public string? Description { get; set; }
        public string? Humidity { get; set; }
        public string? TempFeelsLike { get; set; }
        public string? Temp { get; set; }
        public string? TempMax { get; set; }
        public string? TempMin { get; set; }
        public string? WeatherIcon { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string? Main { get; set; }
        public string? Desciption { get; set; }
        public string? Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }   
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string? Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set;}
    }

    public class RootObject
    {
        public Coord? Coord { get; set; }
        public List<Weather>? Weather { get; set; }
        public string? @base { get; set; }
        public Main? Main { get; set; }
        public int Visibility { get; set; }
        public Wind? Wind { get; set; }
        public Clouds? Clouds { get; set; }
        public int Dt { get; set; }
        public Sys? Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cod { get; set; }
    }
}
