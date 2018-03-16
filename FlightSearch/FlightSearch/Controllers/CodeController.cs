using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSearch.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.Controllers
{
    [Route("api/Code")]
    public class CodeController : Controller
    {
        protected FlightContext db;
        public CodeController(FlightContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetCodes()
        {
            var codes = db.CityCode.Select(x => x.Code).ToList();
            return Ok(codes);
        }
    }
}