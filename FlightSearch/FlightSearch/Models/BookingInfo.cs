using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class BookingInfo
    {
        public int Id { get; set; }
        public string Travel_class { get; set; }
        public string Booking_code { get; set; }
        public int Seats_remaining { get; set; }
        [ForeignKey("FlightId")]
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
