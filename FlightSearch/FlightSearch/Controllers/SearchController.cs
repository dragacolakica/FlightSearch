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
        //[HttpGet]
        //public async Task<IActionResult> RetrieveAndSave()
        //{
        [HttpPost]
        public async Task<IActionResult> RetrieveAndSave([FromBody]Search searchInfo)
        {

            //var searchInfo = new Search()
            //{
            //    Origin = "BOS",
            //    Destination = "LON",
            //    Departure_date = "2018-06-25",
            //    Return_date = "2018-06-28",
            //    Adults = 9,
            //    Currency = "USD"
            //};


            var dbService = new DbService(db);
            var displayFligths = dbService.getSearchData(searchInfo);
            if (displayFligths != null)
            {
                return Ok(displayFligths);
            }

            var URI = String.Format("{0}?apikey={1}&origin={2}&destination={3}&departure_date={4}&adults={5}&currency={6}",
                       ServiceUrl,
                       ApiKey,
                       searchInfo.Origin,
                       searchInfo.Destination,
                       searchInfo.Departure_date.Substring(0, 10),
                       searchInfo.Adults,
                       searchInfo.Currency);

            if (searchInfo.Return_date != "")
            {
                URI += "&return_date=" + searchInfo.Return_date.Substring(0, 10);
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ServiceUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(URI);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            RootObject r = JsonConvert.DeserializeObject<RootObject>(contents);

            searchInfo.RootObject = r;
            db.Search.Add(searchInfo);
            db.SaveChanges();

            var fareCurrentSearch = dbService.getSearchData(searchInfo);
            return Ok(fareCurrentSearch);

        }
    }
}
