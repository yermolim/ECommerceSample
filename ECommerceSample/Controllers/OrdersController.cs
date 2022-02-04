using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostOrder()
        {
            // TODO: implement
            return Ok(true);
        }
    }
}
