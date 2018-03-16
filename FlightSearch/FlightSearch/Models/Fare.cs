using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Fare
    {
        public int Id { get; set; }
        public string Total_price { get; set; }
        public PricePerAdult Price_per_adult { get; set; }
        public Restrictions Restrictions { get; set; }
        [ForeignKey("ResultId")]
        public int ResultId { get; set; }
        public virtual Result Result { get; set; }
    }
}
