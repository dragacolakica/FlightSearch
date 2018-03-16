using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Restrictions
    {
        public int Id { get; set; }
        public bool Refundable { get; set; }
        public bool Change_penalties { get; set; }
        public int FareId { get; set; }
        [ForeignKey("FareId")]
        public virtual Fare Fare { get; set; }
    }
}
