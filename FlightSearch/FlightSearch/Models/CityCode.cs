using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class CityCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Airport { get; set; }
        public string Country { get; set; }
    }
}
