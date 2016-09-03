using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Server.Kestrel.Networking;
using Newtonsoft.Json;
using Twinkle.Server.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Twinkle.Server.Controllers
{
    [Route("api/[controller]")]
    public class WorldController : Controller
    {
        protected readonly TwinkleDataContext _dbContext;

        public WorldController(TwinkleDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public GameWorldsCollection Get(int resultNumber = 50, int? seed = null)
        {
            var random = new Random(seed ?? (int)DateTime.Now.Ticks);
            var resultStrings = _dbContext.Worlds.OrderBy((world) => random.Next()).Take(resultNumber);
            var results = new List<GameWorldData>();
            foreach (var result in resultStrings)
            {
                results.Add(JsonConvert.DeserializeObject<GameWorldData>(result.DataBlob));
            }
            return new GameWorldsCollection() { Worlds = results.ToArray() };
        }

        // POST api/values
        [HttpPost]
        public GameWorldData Post([FromBody]GameWorldData world)
        {
            string serializedBlob = JsonConvert.SerializeObject(world);

            _dbContext.Worlds.Add(new WorldModel() { DataBlob = serializedBlob });
            _dbContext.SaveChanges();

            return world;
        }
    }
}
