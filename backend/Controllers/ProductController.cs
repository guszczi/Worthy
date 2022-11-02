using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("test")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        protected IActionResult GetTest()
        {
            return Ok("It worked!");
        }
    }
}