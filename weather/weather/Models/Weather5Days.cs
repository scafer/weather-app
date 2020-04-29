using System;
using System.Collections.Generic;

namespace weather.Models
{
    public class Weather5Days
    {
        public string owner { get; set; }
        public string country { get; set; }
        public List<Data> data { get; set; }
        public int globalIdLocal { get; set; }
        public DateTime dataUpdate { get; set; }
    }

    public class Data
    {
        public string precipitaProb { get; set; }
        public string tMin { get; set; }
        public string tMax { get; set; }
        public string predWindDir { get; set; }
        public int idWeatherType { get; set; }
        public int classWindSpeed { get; set; }
        public string longitude { get; set; }
        public string forecastDate { get; set; }
        public string latitude { get; set; }
        public int? classPrecInt { get; set; }
    }
}
