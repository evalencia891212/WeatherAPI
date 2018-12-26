using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIWeather.Entities;
using APIWeather.Data;

namespace APIWeather.Business
{
        
    public class BCity
    {
        public List<ECity> GetCities()
        {
            return new DCity().GetCities();
        }
    }
}
