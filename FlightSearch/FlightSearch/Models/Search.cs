using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Search
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Departure_date { get; set; }
        public string Return_date { get; set; }
        public int Adults { get; set; }
        public string Currency { get; set; }
        public RootObject RootObject { get; set; }
    }
}
