using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Inbound
    {
        public int Id { get; set; }
        public List<Flight> Flights { get; set; }
        public int ItineraryId { get; set; }
        [ForeignKey("ItineraryId")]
        public Itinerary Itinerary { get; set; }
    }
}
