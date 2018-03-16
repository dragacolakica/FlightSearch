using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public Outbound Outbound { get; set; }
        public Inbound Inbound { get; set; }
        public int ResultId { get; set; }
        [ForeignKey("ResultId")]
        public virtual Result Result { get; set; }
    }
}
