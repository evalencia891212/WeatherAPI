using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIWeather.Data;
using APIWeather.Entities;

namespace APIWeather.Business
{
    public class BRecord
    {
        public List<ERecord> GetRecords(int cityId, string BeginDate, string EndDate)
        {
            return new DRecord().getRecord(cityId,BeginDate,EndDate); 
        }
    }
}
