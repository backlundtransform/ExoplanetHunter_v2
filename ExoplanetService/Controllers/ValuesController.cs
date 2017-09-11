using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExoplanetService.Models;

namespace ExoplanetService.Controllers
{
    [Produces("application/json")]
    [Route("api/Tests")]
    public class TestController : Controller
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {

            ExoContext context = new ExoContext();

           var data = context.Planets.First();

            return new string[] { "value1", "value2" };
        }
    }
}