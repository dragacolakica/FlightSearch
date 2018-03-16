using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Departs_at { get; set; }
        public string Arrives_at { get; set; }
        public Origin Origin { get; set; }
        public Destination Destination { get; set; }
        public string Marketing_airline { get; set; }
        public string Operating_airline { get; set; }
        public string Flight_number { get; set; }
        public string Aircraft { get; set; }
        public BookingInfo Booking_info { get; set; }
        public int? InboundId { get; set; }
        [ForeignKey("InboundId")]
        public int? OutboundId { get; set; }
        [ForeignKey("OutboundId")]
        public virtual Outbound Outbound { get; set; }
        public virtual Inbound Inbound { get; set; }
    }
}
