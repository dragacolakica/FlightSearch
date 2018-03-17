using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using FlightSearch.DAL;
using FlightSearch.Models;
using FlightSearch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FlightSearch.Controllers
{
    [Route("api/Search")]
    public class SearchController : Controller
    {
        protected FlightContext db;
        protected string ServiceUrl;
        protected string ApiKey;

        public SearchController(IConfiguration configuration, FlightContext context)
        {
            db = context;
            ServiceUrl = configuration.GetSection("Service").GetSection("Url").Value;
            ApiKey = configuration.GetSection("Service").GetSection("ApiKey").Value;
        }

        [HttpPost]
        public async Task<IActionResult> RetrieveAndSave([FromBody]Search searchInfo)
        {
            searchInfo.Return_date = (searchInfo.Return_date != null) ? searchInfo.Return_date.Substring(0, 10) : "";
            searchInfo.Departure_date = searchInfo.Departure_date.Substring(0, 10);

            var dbService = new DbService(db);
            var flightsInfoOld = dbService.getSearchData(searchInfo);
            if (flightsInfoOld.Count() != 0)
            {
                return Ok(flightsInfoOld);
            }

            var queryUrl = String.Format("{0}?apikey={1}&origin={2}&destination={3}&departure_date={4}&adults={5}&currency={6}",
                       ServiceUrl,
                       ApiKey,
                       searchInfo.Origin,
                       searchInfo.Destination,
                       searchInfo.Departure_date,
                       searchInfo.Adults,
                       searchInfo.Currency);

            if (searchInfo.Return_date != "")
            {
                queryUrl += "&return_date=" + searchInfo.Return_date;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ServiceUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(queryUrl);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            RootObject r = JsonConvert.DeserializeObject<RootObject>(contents);

            searchInfo.RootObject = r;
            db.Search.Add(searchInfo);
            db.SaveChanges();

            var flightsInfoNew = dbService.getSearchData(searchInfo);
            return Ok(flightsInfoNew);

        }
    }
}
