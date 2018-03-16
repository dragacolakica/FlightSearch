using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class PricePerAdult
    {
        public int Id { get; set; }
        public string Total_fare { get; set; }
        public string Tax { get; set; }
        public int FareId { get; set; }
        [ForeignKey("FareId")]
        public virtual Fare Fare { get; set; }
    }
}
