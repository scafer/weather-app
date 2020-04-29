using System.Collections.Generic;

namespace weather.Models
{
    public class DistrictIslands
    {
        public string owner { get; set; }
        public string country { get; set; }
        public List<District> data { get; set; }
    }

    public class District
    {
        public int idRegiao { get; set; }
        public string idAreaAviso { get; set; }
        public int idConcelho { get; set; }
        public int globalIdLocal { get; set; }
        public string latitude { get; set; }
        public int idDistrito { get; set; }
        public string local { get; set; }
        public string longitude { get; set; }
    }
}
