using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public WeatherForecast Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool Buy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
