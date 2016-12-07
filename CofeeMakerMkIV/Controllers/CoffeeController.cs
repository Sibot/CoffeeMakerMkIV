using System.Collections.Generic;
using System.Web.Mvc;

namespace CofeeMakerMkIV.Controllers
{
    public class CoffeeController
    {
        [HttpGet]
        public IEnumerable<string> Make()
        {
            return new [] {"Coffee"};
        }
    }
}
