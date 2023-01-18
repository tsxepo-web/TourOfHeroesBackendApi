﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HeroesWeatherService.DTO
{
    public class OpenWeatherResponse
    {
        public Main main {get; set;} = null!;
    }
    public class Main
    {
        public double temp { get; set; }
    }
}
