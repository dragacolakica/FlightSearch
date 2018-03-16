using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Origin
    {
        public int Id { get; set; }
        public string Airport { get; set; }
        public string Terminal { get; set; }
        [ForeignKey("flightId")]
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
