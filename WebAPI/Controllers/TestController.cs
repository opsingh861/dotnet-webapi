using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var data = new { name = "Aditya Dhanraj" }; // created json data
            return Ok(data);
        }
    }
}
