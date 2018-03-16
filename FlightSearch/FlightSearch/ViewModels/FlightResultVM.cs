using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.ViewModels
{
    public class FlightResultVM
    {
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public int? OutBoundCount { get; set; }
        public int InBoundCount { get; set; }
        public int Adults { get; set; }
        public string TotalPrice { get; set; }
        public string Currency { get; set; }
    }
}
