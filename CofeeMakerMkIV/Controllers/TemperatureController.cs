using System.Collections.Generic;
using System.Web.Http;

namespace CofeeMakerMkIV.Controllers
{
    public class TemperatureController
    {
        // GET api/temperature
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // POST api/temperature
        [HttpPost]
        public void Post([FromBody]int value)
        {
        }

        // PUT api/temperature/5
        [HttpPut]
        public void Put(int value)
        {
        }

        // DELETE api/temperature/5
        [HttpDelete]
        public void Delete(int value)
        {
        }
    }
}
