using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Models
{
    public class RootObject
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public IList<Result> Results { get; set; }
        public int SearchId { get; set; }
        [ForeignKey("SearchId")]
        public virtual Search Search { get; set; }
    }
}
