using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWeather.Entities
{
    [Serializable]
    public class ERecord
    {
        public int cityId { get; set; }
        public string date { get; set; }
        public int temperature { get; set; }
    }
}