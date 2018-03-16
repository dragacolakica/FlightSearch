using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Result
    {
        public int Id { get; set; }
        public IList<Itinerary> Itineraries { get; set; }
        public Fare Fare { get; set; }
        public int RootObjectId { get; set; }
        [ForeignKey("RootObjectId")]
        public virtual RootObject RootObject { get; set; }
    }
}
