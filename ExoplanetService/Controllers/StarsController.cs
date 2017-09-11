using ExoplanetService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoplanetService.Controllers
{
    [Produces("application/json")]
    [Route("api/Constellations")]
    public class StarsController : Controller
    {
        private ExoContext context = new ExoContext() { };

        [HttpGet]
        public async Task<IEnumerable<Constellation>> Get()
        {
            return await Task.Run(() => context.Constellations.Where(p => true));
        }

        [HttpGet("{cid}")]
        public async Task<object> Get(int cid)
        {
            var constellation = await context.Constellations.SingleOrDefaultAsync(c => c.Id == cid);

            var stars = await Task.Run(() => context.Stars.Where(c => c.Constellation.Id == cid));

            return new { Constellation = constellation, Stars = stars.Count() };
        }


        [HttpGet("{cid}/stars")]
        public async Task<object> GetStars(int cid)
        {
            var constellation = await context.Constellations.SingleOrDefaultAsync(c => c.Id == cid);

            var stars = await Task.Run(() => context.Stars.Where(c => c.Constellation.Id == cid));

            return new { Constellation = constellation, Stars = stars };
        }

        [HttpGet("{cid}/stars/{sid}")]
        public async Task<object> GetStar(int sid)
        {
            var star = await context.Stars.SingleOrDefaultAsync(c => c.Id == sid);

            var planets = await Task.Run(() => context.Planets.Where(c => c.Star.Id == sid));

            return new { Star = star, Planets = planets.Count() };
        }

        [HttpGet("{cid}/stars/{sid}/planets")]
        public async Task<object> GetPlanets(int sid)
        {
            var planets = await Task.Run(() => context.Planets.Where(c => c.Star.Id == sid));
            return new { Star = sid, Planets = planets };
        }

        [HttpGet("{cid}/stars/{sid}/planets/{pid}")]
        public async Task<object> GetPlanet( int pid)
        {
            var planet = await Task.Run(() => context.Planets.SingleOrDefaultAsync(c => c.Id == pid));
            return planet;
        }
    }
}