using FlightSearch.DAL;
using FlightSearch.Models;
using FlightSearch.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch
{
    public class DbService
    {
        protected FlightContext db;

        public DbService(FlightContext context)
        {
            db = context;
        }
        public IEnumerable<FlightResultVM> getSearchData(Search searchInfo)
        {
            var flightsInfo = new List<FlightResultVM>();
            var oldSearch = db.Search.Where(x => x.Origin == searchInfo.Origin && x.Destination == searchInfo.Destination && x.Departure_date == searchInfo.Departure_date.Substring(0, 10) && x.Return_date == ((searchInfo.Return_date != "") ? searchInfo.Return_date.Substring(0, 10) : "")).SingleOrDefault();
            if (oldSearch != null)
            {
                var root = db.RootObject.Include(x => x.Results).Where(x => x.SearchId == oldSearch.Id).SingleOrDefault();
                var results = root.Results;

                foreach (var r in results)
                {
                    var flightInfo = new FlightResultVM();
                    flightInfo.OriginName = oldSearch.Origin;
                    flightInfo.DestinationName = oldSearch.Destination;
                    flightInfo.DepartureDate = oldSearch.Departure_date;
                    flightInfo.ReturnDate = oldSearch.Return_date;
                    flightInfo.Adults = oldSearch.Adults;
                    flightInfo.Currency = r.RootObject.Currency;

                    flightInfo.TotalPrice = db.Fare.Where(x => x.ResultId == r.Id).Select(x => x.Total_price).SingleOrDefault();

                    var itinerariesIds = db.Itinerary.Where(x => x.ResultId == r.Id).Select(x => x.Id).ToList();
                    var outboundIds = db.Outbound.Where(x => itinerariesIds.Contains(x.ItineraryId)).Select(x => x.Id).ToList();
                    var inboundIds = db.Inbound.Where(x => itinerariesIds.Contains(x.ItineraryId)).Select(x => x.Id).ToList();

                    var outboundFlights = db.Flight.Where(x => outboundIds.Contains(x.OutboundId.Value)).ToList();
                    var inboundFlights = db.Flight.Where(x => inboundIds.Contains(x.InboundId.Value)).ToList();

                    flightInfo.OutBoundCount = outboundFlights.Count();
                    flightInfo.InBoundCount = inboundFlights.Count();

                    flightsInfo.Add(flightInfo);
                }
            }
            return flightsInfo;
        }
    }
}
