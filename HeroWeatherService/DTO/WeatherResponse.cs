﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesWeatherService.DTO
{
    public class WeatherResponse
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set;}
    }
}
