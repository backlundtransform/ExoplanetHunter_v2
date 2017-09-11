using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExoplanetService.Models;


namespace ExoplanetService.Controllers
{

    
    [Produces("application/json")]
    [Route("api/Planets")]

    public class PlanetsController : Controller
    {
        private ExoContext context = new ExoContext() { };

        [HttpGet]
        public async Task<IEnumerable<Planet>> Get(string filter=null)
        {



            if(filter != null)
            {

               var filterarray = filter.Split(' ');

                if(filterarray.Count() == 3) {

                    try { 

                    switch (filterarray[1])
                    {

                        case "eq":
                            return await Task.Run(() => context.Planets.Where(p => p.GetType().GetProperty(filterarray[0]).GetValue(p, null).ToString() == filterarray[2]).ToList());

                        case "gt":
                            return await Task.Run(() => context.Planets.Where(p => Convert.ToDecimal(p.GetType().GetProperty(filterarray[0]).GetValue(p, null)) > Convert.ToDecimal(filterarray[2])));
                        case "gte":
                            return await Task.Run(() => context.Planets.Where(p => Convert.ToDecimal(p.GetType().GetProperty(filterarray[0]).GetValue(p, null)) >= Convert.ToDecimal(filterarray[2])));
                        case "lt":
                            return await Task.Run(() => context.Planets.Where(p => Convert.ToDecimal(p.GetType().GetProperty(filterarray[0]).GetValue(p, null)) < Convert.ToDecimal(filterarray[2])));
                        case "lte":
                            return await Task.Run(() => context.Planets.Where(p => Convert.ToDecimal(p.GetType().GetProperty(filterarray[0]).GetValue(p, null)) <= Convert.ToDecimal(filterarray[2])));

                    }
                    }
                    catch (Exception e) {

                        return await Task.Run(() => context.Planets.Where(p => true));

                    }


                }
            }

            return await Task.Run(() => context.Planets.Where(p => true));


        }


    }
}